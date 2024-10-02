using MediatR;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.behaviours
{
    //thực hiện xác thực trước khi yêu cầu MediatR truy vấn 
    //IPipelineBehaviorcho phép các hành vi chạy trước hoặc sau khi yêu cầu được xử lý.
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull//TRequest không được null.
    {
        //tập hợp các trình xác thực
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        // request: Yêu cầu lệnh hoặc truy vấn đang được xử lý.
        // next: Đại biểu gọi hành vi tiếp theo trong  trình xử lý thực tế nếu đây là hành vi cuối cùng.
        // cancellationToken: Cho phép hủy bỏ thao tác.
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //kiểm tra xem có trình xác thực nào cho TRequest
            if (_validators.Any())
            {
                //Tạo ngữ cảnh xác thực cho request
                var context = new ValidationContext<TRequest>(request);
                //Chạy xác thực không đồng bộ cho tất cả các trình xác thựccho yêu cầu.
                var validationResult = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                //Lọc ra các kết quả thành công và chỉ giữ lại các lỗi xác thực.
                var failures = validationResult.Where(r => r.Errors.Any())
                                                .SelectMany(r => r.Errors)// lấy danh sách lỗi thu thu thập vào danh sách
                                                .ToList();
                if (failures.Any())
                    throw new ValidationException(failures);
            }
            //Nếu không có lỗi xác thực, phương thức này sẽ gọi next()
            return await next();
        }
    }
}
