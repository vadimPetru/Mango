using Mango.Services.AuthAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponApi.MIdlware
{
    public class ApplyMigrationMiddleware
    {
        private readonly RequestDelegate _next;

        public ApplyMigrationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Этот код выполняет проверку наличия и применение непримененных миграций к базе данных при каждом HTTP-запросе.
        /// Это может быть полезно для автоматического обновления структуры базы данных при изменениях в моделях данных приложения.
        /// </summary>
        /// <param name="context">Контехт приложения</param>
        /// <param name="next"> Делегад для передачи следуюшими middleware</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = context.RequestServices.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if( _db.Database.GetPendingMigrations().Count() > 0)
                {
                    await _db.Database.MigrateAsync();
                }
            }
            await _next(context);
        }


       

       
    }
}
