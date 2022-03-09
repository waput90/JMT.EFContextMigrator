using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JMT.EFContextMigrator.Core
{
    public static class MigratorLayer
    {
        public static IApplicationBuilder RegisterMigratorMiddleware<TContext>(this IApplicationBuilder app) where TContext: DbContext
        {
            try
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<TContext>();
                    db.Database.Migrate();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return app;
        }
    }
}
