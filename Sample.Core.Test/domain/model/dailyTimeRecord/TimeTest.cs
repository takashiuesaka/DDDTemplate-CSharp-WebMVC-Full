using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Core.domain.model.dailyTimeRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.Test.domain.model.dailyTimeRecord
{
    // （労働基準法より営業時間の切り替わりは朝５時）
    // 時間が5時丁度から23時59分までの場合_営業日とカレンダー日は同じ
    // 時間が0時丁度から4時59分の場合_営業日に対してカレンダー日は翌日
    // 
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void 時間が5時丁度の場合_営業日とカレンダー日は同じ()
        {
            var target = Time.Create(new CalendarDate(new DateTime(2021, 4, 1)), 5, 0);

            Assert.AreEqual(new DateTime(2021, 4, 1, 5, 0, 0), target.CalendarDateTime);
        }

        [TestMethod]
        public void 時間が5時1分の場合_営業日とカレンダー日は同じ()
        {
            var target = Time.Create(new CalendarDate(new DateTime(2021, 4, 1)), 5, 1);

            Assert.AreEqual(new DateTime(2021, 4, 1, 5, 1, 0), target.CalendarDateTime);
        }

        [TestMethod]
        public void 時間が23時59分の場合_営業日とカレンダー日は同じ()
        {
            var target = Time.Create(new CalendarDate(new DateTime(2021, 4, 1)), 23, 59);

            Assert.AreEqual(new DateTime(2021, 4, 1, 23, 59, 0), target.CalendarDateTime);
        }

        [TestMethod]
        public void 時間が0時丁度の場合_営業日に対してカレンダー日は翌日()
        {
            var target = Time.Create(new CalendarDate(new DateTime(2021, 4, 1)), 0, 0);

            Assert.AreEqual(new DateTime(2021, 4, 2, 0, 0, 0), target.CalendarDateTime);
        }

        [TestMethod]
        public void 時間が0時1分の場合_営業日に対してカレンダー日は翌日()
        {
            var target = Time.Create(new CalendarDate(new DateTime(2021, 4, 1)), 0, 1);

            Assert.AreEqual(new DateTime(2021, 4, 2, 0, 1, 0), target.CalendarDateTime);
        }

        [TestMethod]
        public void 時間が4時59分の場合_営業日に対してカレンダー日は翌日()
        {
            var target = Time.Create(new CalendarDate(new DateTime(2021, 4, 1)), 4, 59);

            Assert.AreEqual(new DateTime(2021, 4, 2, 4, 59, 0), target.CalendarDateTime);
        }
    }
}
