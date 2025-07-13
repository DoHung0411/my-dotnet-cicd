# Giai đoạn 1: Build ứng dụng
# Sử dụng image .NET Core 3.1 SDK để build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Sao chép file solution và project để restore các package một cách hiệu quả
COPY ["MyDotNetApp/MyDotNetApp.sln", "MyDotNetApp/"]
COPY ["MyDotNetApp/MyDotNetApp/MyDotNetApp.csproj", "MyDotNetApp/MyDotNetApp/"]
RUN dotnet restore "MyDotNetApp/MyDotNetApp.sln"

# Sao chép toàn bộ source code của dự án
COPY . .
WORKDIR "/app/MyDotNetApp/MyDotNetApp"

# Build và publish ứng dụng với cấu hình Release
RUN dotnet publish -c Release -o /app/out

# Giai đoạn 2: Tạo image cuối cùng để chạy ứng dụng
# Sử dụng image ASP.NET Core 3.1 runtime, nhẹ hơn image SDK
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

# Mở port 80 cho container
EXPOSE 80

# Entrypoint để chạy ứng dụng khi container khởi động
ENTRYPOINT ["dotnet", "MyDotNetApp.dll"] 