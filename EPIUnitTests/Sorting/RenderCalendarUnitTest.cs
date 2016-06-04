using System;
using System.Collections.Generic;
using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class RenderCalendarUnitTest
	{
		[TestMethod]
		public void FindMaxConcurrentCalendarEvents()
		{
			List<RenderCalendar.CalendarEvent> calendar = new List<RenderCalendar.CalendarEvent>()
			{
				new RenderCalendar.CalendarEvent(new DateTime(2016,6,4,1,0,0), new DateTime(2016,6,4,5,0,0)),
				new RenderCalendar.CalendarEvent(new DateTime(2016,6,4,6,0,0), new DateTime(2016,6,4,10,0,0)),
				new RenderCalendar.CalendarEvent(new DateTime(2016,6,4,11,0,0), new DateTime(2016,6,4,13,0,0)),
				new RenderCalendar.CalendarEvent(new DateTime(2016,6,4,14,0,0), new DateTime(2016,6,4,15,0,0)),
				new RenderCalendar.CalendarEvent(new DateTime(2016,6,4,2,0,0), new DateTime(2016,6,4,7,0,0)),
				new RenderCalendar.CalendarEvent(new DateTime(2016,6,4,8,0,0), new DateTime(2016,6,4,9,0,0)),
				new RenderCalendar.CalendarEvent(new DateTime(2016,6,4,12,0,0), new DateTime(2016,6,4,15,0,0)),
				new RenderCalendar.CalendarEvent(new DateTime(2016,6,4,4,0,0), new DateTime(2016,6,4,5,0,0)),
				new RenderCalendar.CalendarEvent(new DateTime(2016,6,4,9,0,0), new DateTime(2016,6,4,17,0,0))
			};
			RenderCalendar.FindMaxConcurrentEvents(calendar).Should().Be(3);
		}
	}
}
