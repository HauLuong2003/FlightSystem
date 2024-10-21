using AutoMapper;

using FlightSystem.Domain.Entities;

using System.Reflection;
using System.Runtime.InteropServices;
namespace Application.Common.Mapping
{
    public class AutoMapperProfile : Profile //Nó được sử dụng để nhóm các cấu hình ánh xạ lại với nhau.
    {
        public AutoMapperProfile()
        {
//  quét toàn bộ cụm để tìm các kiểu triển khai IMapFrom<T> và tự động áp dụng các ánh xạ của chúng.
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
         
        }
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
        //Nó sẽ được sử dụng để tìm tất cả các lớp triển khai giao diện này với bất kỳ kiểu nào làm tham số.
            var mapFromType = typeof(IMapFrom<>);
        //lấy tên phương Mappingthức từ IMapFrom<object>giao diện. 
            var mappingMethodName = nameof(IMapFrom<object>.Mapping);
        //kiểm tra xem một kiểu dữ liệu nhất định tcó phải là kiểu chung hay không và liệu nó có khớp với IMapFrom<> hay không
            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;
        //Thao tác này sẽ truy xuất tất cả các kiểu được xuất từ ​​cụm từ đã cho và lọc chúng xuống
        //chỉ còn những kiểu triển khai IMapFrom<T>cho bất kỳ kiểu nào T.
        //Kiễm tra có khớp với IMapFrom<>
            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();
        //một mảng các kiểu đối số để gọi phương thức sau này. Vì Mappingphương thức lấy một Profileđối tượng làm đối số
            var argumentTypes = new Type[] { typeof(Profile) };
         //Vòng lặp này lặp lại tất cả các kiểu được xác định là triển khai
            foreach (var type in types)
            {
                //được sử dụng để tạo động một đối tượng của kiểu được chỉ định khi chạy thời gian thực.
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(mappingMethodName);

                if (methodInfo != null)
                {
                    //Phương thức này sẽ gọi Mappingphương thức một cách động, truyền phiên bản hiện tại của AutoMapperProfile
                    methodInfo.Invoke(instance, new object[] { this });
                }
                else
                {
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                    if (interfaces.Count > 0)
                    {
                        foreach (var @interface in interfaces)
                        {
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                            interfaceMethodInfo?.Invoke(instance, new object[] { this });
                        }
                    }
                }
            }
        }
    }
}
