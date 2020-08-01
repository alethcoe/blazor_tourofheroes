using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bunit;
using Moq;
using tour_of_heroes.Components;
using Microsoft.AspNetCore.Components;
using tour_of_heroes.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using tour_of_heroes.Models;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System.Security.Cryptography;

namespace TourOfHeroesTests
{

	public class HeroesTest : TestContext
	{
		[Fact]
		public void PracticeTest()
		{
			var HeroServiceMoq = new Mock<IHeroService>();
			HeroServiceMoq.Setup(m => m.GetHeroes())
				.Returns(Task.FromResult(new Hero[] { new Hero() { Name = "Baconman", Id = -1 } }));
			//.Returns(new TaskCompletionSource<Hero[]>().Task);
			var NavigationManagerMoq = new Mock<NavigationManager>();
			var MessagagingServiceMoq = new Mock<IMessagingService>();

			Services.AddSingleton<IHeroService>(HeroServiceMoq.Object);
			Services.AddSingleton<NavigationManager>(NavigationManagerMoq.Object);
			Services.AddSingleton<IMessagingService>(MessagagingServiceMoq.Object);

			var cut = RenderComponent<Heroes>();
			cut.Find("li").MarkupMatches(@"<li><span class=""badge"">-1</span> Baconman</li>");
		}
	}
}
