using Dapper;
using ShopApp.Discount.Context;
using ShopApp.Discount.Dtos;
using System.Globalization;
using System.Reflection.Metadata;

namespace ShopApp.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@code", createCouponDto.Code);
            parametrs.Add("@rate", createCouponDto.Rate);
            parametrs.Add("@isActive", createCouponDto.IsActive);
            parametrs.Add("@validDate", createCouponDto.ValidDate);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "delete from Coupons where CouponId=@couponId";
            var parametrs = new DynamicParameters();
            parametrs.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async  Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIsCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "select * from Coupons where CouponId=@couponId";
            var parametrs = new DynamicParameters();
            parametrs.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIsCouponDto>(query,parametrs);
                return value;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parametrs = new DynamicParameters();
            parametrs.Add("@couponId", updateCouponDto.CouponId);
            parametrs.Add("@code", updateCouponDto.Code);
            parametrs.Add("@rate", updateCouponDto.Rate);
            parametrs.Add("@isActive", updateCouponDto.IsActive);
            parametrs.Add("@validDate", updateCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
