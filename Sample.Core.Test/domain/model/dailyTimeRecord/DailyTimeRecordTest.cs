using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Core.domain.model.dailyTimeRecord;
using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.Test.domain.model.dailyTimeRecord
{
    // 勤務時間＝退勤時間ー開始時間
    // 労働時間は退勤時間 - 開始時間 - 休憩時間

    // 労働時間が６時間以下（６時間を含む）場合は休憩時間はなし
    // 労働時間が６時間１分から８時間以下（８時間を含む）場合は休憩時間は45分であること
    // 労働時間が８時間１分を超える場合、休憩時間は１時間であること
    // 労働時間が８時間と１分を超える場合、超えた分を残業時間とする
    //
    [TestClass]
    public class DailyTimeRecordTest
    {
        internal DailyTimeRecord Target;

        [TestInitialize]
        public void InitializeMethod()
        {
            this.Target = new DailyTimeRecord(
                new Identity(),
                new CalendarDate(new DateTime(2021, 4, 1)),
                Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)),
                Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)),
                TimeSpan.Zero,
                TimeSpan.Zero,
                TimeSpan.Zero);
        }

        #region 勤務時間が6時間の場合

        [TestCategory("ctgy01_勤務時間が6時間の場合")]
        [TestMethod]
        public void ctgy01_労働時間は6時間()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 15, 0, 0)));

            Assert.AreEqual(TimeSpan.FromHours(6), Target.WorkingHours);
        }

        [TestCategory("ctgy01_勤務時間が6時間の場合")]
        [TestMethod]
        public void ctgy01_休憩時間はゼロ()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 15, 0, 0)));

            Assert.AreEqual(TimeSpan.Zero, Target.BreakTime);
        }

        [TestCategory("ctgy01_勤務時間が6時間の場合")]
        [TestMethod]
        public void ctgy01_残業時間はゼロ()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 15, 0, 0)));

            Assert.AreEqual(TimeSpan.Zero, Target.OvertimeHours);

        }
        #endregion

        #region 勤務時間が5時間59分の場合
        [TestCategory("ctgy02_勤務時間が5時間59分の場合")]
        [TestMethod]
        public void ctgy02_労働時間は5時間59分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 14, 59, 0)));

            Assert.AreEqual(TimeSpan.FromHours(5).Add(TimeSpan.FromMinutes(59)), Target.WorkingHours);
        }

        [TestCategory("ctgy02_勤務時間が5時間59分の場合")]
        [TestMethod]
        public void ctgy02_休憩時間はゼロ()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 14, 59, 0)));

            Assert.AreEqual(TimeSpan.Zero, Target.BreakTime);
        }

        [TestCategory("ctgy02_勤務時間が5時間59分の場合")]
        [TestMethod]
        public void ctgy02_残業時間はゼロ()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 14, 59, 0)));

            Assert.AreEqual(TimeSpan.Zero, Target.OvertimeHours);
        }
        #endregion

        #region 勤務時間が6時間1分の場合
        [TestCategory("ctgy03_勤務時間が6時間1分の場合")]
        [TestMethod]
        public void ctgy03_労働時間は5時間46分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 15, 1, 0)));

            Assert.AreEqual(TimeSpan.FromHours(5).Add(TimeSpan.FromMinutes(16)), Target.WorkingHours);

        }

        [TestCategory("ctgy03_勤務時間が6時間1分の場合")]
        [TestMethod]
        public void ctgy03_休憩時間は45分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 15, 1, 0)));

            Assert.AreEqual(TimeSpan.FromMinutes(45), Target.BreakTime);
        }

        [TestCategory("ctgy03_勤務時間が6時間1分の場合")]
        [TestMethod]
        public void ctgy03_残業時間はゼロ()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 15, 1, 0)));

            Assert.AreEqual(TimeSpan.Zero, Target.OvertimeHours);
        }
        #endregion

        #region 勤務時間が8時間の場合
        [TestCategory("ctgy04_勤務時間が8時間の場合")]
        [TestMethod]
        public void ctgy04_労働時間は7時間15分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 17, 0, 0)));

            Assert.AreEqual(TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(15)), Target.WorkingHours);
        }

        [TestCategory("ctgy04_勤務時間が8時間の場合")]
        [TestMethod]
        public void ctgy04_休憩時間は45分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 17, 0, 0)));

            Assert.AreEqual(TimeSpan.FromMinutes(45), Target.BreakTime);
        }

        [TestCategory("ctgy04_勤務時間が8時間の場合")]
        [TestMethod]
        public void ctgy04_残業時間はゼロ()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 17, 0, 0)));

            Assert.AreEqual(TimeSpan.Zero, Target.OvertimeHours);
        }
        #endregion

        #region 勤務時間が7時間59分の場合
        [TestCategory("ctgy05_勤務時間が7時間59分の場合")]
        [TestMethod]
        public void ctgy05_労働時間は7時間14分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 16, 59, 0)));

            Assert.AreEqual(TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(14)), Target.WorkingHours);
        }

        [TestCategory("ctgy05_勤務時間が7時間59分の場合")]
        [TestMethod]
        public void ctgy05_休憩時間は45分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 16, 59, 0)));

            Assert.AreEqual(TimeSpan.FromMinutes(45), Target.BreakTime);
        }

        [TestCategory("ctgy05_勤務時間が7時間59分の場合")]
        [TestMethod]
        public void ctgy05_残業時間はゼロ()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 16, 59, 0)));
            Assert.AreEqual(TimeSpan.Zero, Target.OvertimeHours);
        }
        #endregion

        #region 勤務時間が8時間1分の場合
        [TestCategory("ctgy06_勤務時間が8時間1分の場合")]
        [TestMethod]
        public void ctgy06_労働時間は7時間1分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 17, 01, 0)));

            Assert.AreEqual(TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(1)), Target.WorkingHours);
        }

        [TestCategory("ctgy06_勤務時間が8時間1分の場合")]
        [TestMethod]
        public void ctgy06_休憩時間は1時間()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 17, 01, 0)));
            Assert.AreEqual(TimeSpan.FromHours(1), Target.BreakTime);
        }

        [TestCategory("ctgy06_勤務時間が8時間1分の場合")]
        [TestMethod]
        public void ctgy06_残業時間はゼロ()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 17, 01, 0)));

            Assert.AreEqual(TimeSpan.Zero, Target.OvertimeHours);
        }
        #endregion

        [TestCategory("ctgy07_勤務時間が9時間1分の場合")]
        [TestMethod]
        public void ctgy07_労働時間は8時間1分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 18, 01, 0)));

            Assert.AreEqual(TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(1)), this.Target.WorkingHours);
        }

        [TestCategory("ctgy07_勤務時間が9時間1分の場合")]
        [TestMethod]
        public void ctgy07_休憩時間は1時間()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 18, 01, 0)));

            Assert.AreEqual(TimeSpan.FromHours(1), this.Target.BreakTime);
        }

        [TestCategory("ctgy07_勤務時間が9時間1分の場合")]
        [TestMethod]
        public void ctgy07_残業時間は1分()
        {
            this.Target.Recalcurate(Time.Create(new DateTime(2021, 4, 1, 9, 0, 0)), Time.Create(new DateTime(2021, 4, 1, 18, 01, 0)));

            Assert.AreEqual(TimeSpan.FromMinutes(1), Target.OvertimeHours);
        }
    }
}
