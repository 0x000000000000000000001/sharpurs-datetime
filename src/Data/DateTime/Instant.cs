using System;

namespace Data.DateTime.Instant;

public static class FFI {
    public static double FromDateTimeImpl(long y, long mo, long d, long h, long mi, long s, long ms) {
        var dt = new System.DateTime((int)y, (int)mo, (int)d, (int)h, (int)mi, (int)s, (int)ms, DateTimeKind.Utc);
        return new DateTimeOffset(dt).ToUnixTimeMilliseconds();
    }
    
    public static object ToDateTimeImpl(Func<long, Func<long, Func<long, Func<long, Func<long, Func<long, Func<long, object>>>>>>> ctor, double instant) {
        var dt = DateTimeOffset.FromUnixTimeMilliseconds((long)instant).UtcDateTime;
        return ctor(dt.Year)(dt.Month)(dt.Day)(dt.Hour)(dt.Minute)(dt.Second)(dt.Millisecond);
    }
}
