using System;

namespace Data.Date;

public static class FFI {
    private static DateTime CreateDate(long y, long m, long d) {
        return new DateTime((int)y, (int)m, (int)d, 0, 0, 0, DateTimeKind.Utc);
    }
    
    public static object CanonicalDateImpl(Func<long, Func<long, Func<long, object>>> ctor, long y, long m, long d) {
        var date = CreateDate(y, m, d);
        return ctor(date.Year)(date.Month)(date.Day);
    }
    
    public static long CalcWeekday(long y, long m, long d) {
        var date = CreateDate(y, m, d);
        return (long)date.DayOfWeek;
    }
    
    public static double CalcDiff(long y1, long m1, long d1, long y2, long m2, long d2) {
        var dt1 = CreateDate(y1, m1, d1);
        var dt2 = CreateDate(y2, m2, d2);
        return (dt1 - dt2).TotalMilliseconds;
    }
}
