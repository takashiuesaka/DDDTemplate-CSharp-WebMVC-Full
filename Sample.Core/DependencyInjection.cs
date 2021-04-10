using Microsoft.Extensions.DependencyInjection;
using Sample.Core.application;
using Sample.Core.application.impl;
using Sample.Core.interfaces;
using Sample.Core.interfaces.impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core
{
    public static class DependencyInjection
    {
        public static void SetUp(IServiceCollection services)
        {
            services.AddTransient<ITimeRecordingUseCase, TimeRecordingUseCase>();
            services.AddTransient<ITimeRecordingService, TimeRecordingService>();
        }
    }
}
