namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Items;
    using FastFood.Web.ViewModels.Orders;
    using Models;
    using System.Globalization;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));
            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(x => x.Id));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(x => x.Position.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name));
            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x=>x.CategoryId,y=>y.MapFrom(x=>x.Id));

            this.CreateMap<CreateItemInputModel, ItemsAllViewModels>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x=>x.Category,y=>y.MapFrom(x=>x.Category.Name));

            //Orders
            this.CreateMap<CreateOrderInputModel, Order>();


            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.OrderId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Employee, y => y.MapFrom(x => x.Employee.Name))
                .ForMember(x=>x.DateTime,y=>y.MapFrom(x=>x.DateTime.ToString("dd-MM-yyyy HH:mm",
                CultureInfo.InvariantCulture)));




        }
    }
}
