﻿using Microsoft.OpenApi.Models;

namespace API.Extentions
{
	public static class SwaggerServiceExtentions
	{
		public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce", Version = "v1" });
				var securitySchema = new OpenApiSecurityScheme
				{
					Description = "JWT Auth Bearer Scheme",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				};
				c.AddSecurityDefinition("Bearer", securitySchema);
				var securityRequirement = new OpenApiSecurityRequirement
				{
					{securitySchema,new[]{"Bearer"} }
				};
				c.AddSecurityRequirement(securityRequirement);
			});
			return services;
		}
		public static IApplicationBuilder UserSwaggerDocumentation(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce App");
			});
			return app;
		}
	}
}
