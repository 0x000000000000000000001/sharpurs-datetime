using System;
using System.Collections.Generic;
using DictStrObj = System.Collections.Generic.Dictionary<string, object>;
using FuncObjObj = System.Func<object, object>;

namespace Data.DateTime;

public static class FFI {
    private static global::System.DateTime CreateUTC(long y, long mo, long d, long h, long m, long s, long ms) {
        return new global::System.DateTime((int)y, (int)mo, (int)d, (int)h, (int)m, (int)s, (int)ms, global::System.DateTimeKind.Utc);
    }

    private static long GetInt(Dictionary<string, object> m, string key) {
        return (long)m[key];
    }
    
    public static double CalcDiff(DictStrObj rec1, DictStrObj rec2) {
        var msUTC1 = CreateUTC(GetInt(rec1, "year"), GetInt(rec1, "month"), GetInt(rec1, "day"), GetInt(rec1, "hour"), GetInt(rec1, "minute"), GetInt(rec1, "second"), GetInt(rec1, "millisecond"));
        var msUTC2 = CreateUTC(GetInt(rec2, "year"), GetInt(rec2, "month"), GetInt(rec2, "day"), GetInt(rec2, "hour"), GetInt(rec2, "minute"), GetInt(rec2, "second"), GetInt(rec2, "millisecond"));
        return (msUTC1 - msUTC2).TotalMilliseconds;
    }
    
    public static object AdjustImpl(FuncObjObj just, object nothing, double offset, DictStrObj rec) {
        var t = CreateUTC(GetInt(rec, "year"), GetInt(rec, "month"), GetInt(rec, "day"), GetInt(rec, "hour"), GetInt(rec, "minute"), GetInt(rec, "second"), GetInt(rec, "millisecond"));
        var dt = t.AddMilliseconds(offset);
        
        var resMap = new Dictionary<string, object>();
        resMap["year"] = (long)dt.Year;
        resMap["month"] = (long)dt.Month;
        resMap["day"] = (long)dt.Day;
        resMap["hour"] = (long)dt.Hour;
        resMap["minute"] = (long)dt.Minute;
        resMap["second"] = (long)dt.Second;
        resMap["millisecond"] = (long)dt.Millisecond;
        
        return just(resMap);
    }
}
