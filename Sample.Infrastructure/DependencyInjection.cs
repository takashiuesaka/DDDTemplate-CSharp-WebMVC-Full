using Microsoft.Extensions.DependencyInjection;
using Sample.Core.domain.model.dailyTimeRecord;
using Sample.Infrastructure.persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure
{
    public static class DependencyInjection
    {
        public static void SetUp(IServiceCollection services)
        {
            services.AddTransient<IDailyTimeRecordRepository, DailyTimeRecordRepository>();
        }
    }
}
