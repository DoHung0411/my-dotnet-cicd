using Xunit;
using MyDotNetApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MyDotNetApp.Tests
{
    public class TestControllerTests
    {
        [Fact]
        public void Get_ReturnsOkResult_WithCorrectMessage()
        {
            // Arrange: Khởi tạo các đối tượng cần thiết cho bài test.
            // Trong trường hợp này là tạo một instance của TestController.
            var controller = new TestController();

            // Act: Thực thi phương thức mà chúng ta muốn kiểm thử.
            var result = controller.Get();

            // Assert: Kiểm tra xem kết quả trả về có đúng như mong đợi không.
            
            // 1. Kiểm tra xem kết quả có phải là một OkObjectResult (HTTP 200 OK với body) không.
            var okResult = Assert.IsType<OkObjectResult>(result);

            // 2. Kiểm tra xem giá trị trả về có null không.
            Assert.NotNull(okResult.Value);

            // 3. (Nâng cao hơn) Kiểm tra nội dung của message.
            // Chúng ta cần ép kiểu giá trị về một kiểu có thể truy cập được.
            // Ở đây dùng một mẹo nhỏ với `dynamic` để đọc thuộc tính 'message' từ một anonymous type.
            dynamic value = okResult.Value;
            string message = value.GetType().GetProperty("message").GetValue(value, null);

            Assert.Equal("Hello from Test API!", message);
        }
    }
} 