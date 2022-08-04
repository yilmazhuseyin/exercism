using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {       
        if(id == null)
            return $"{name} - {department?.ToUpper() ?? "OWNER"}";
        else
            return $"[{id}] - {name} - {department?.ToUpper() ?? "OWNER"}";
    }
}

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {       
        string dep = department?.ToUpper();
        if(id == null) return $"{name} - {dep ?? "OWNER"}";
        else return $"[{id}] - {name} - {dep ?? "OWNER"}";
    }
}


static class Badge
{
    public static string Print(int? id, string name, string? department)
    {       
        string dep = department?.ToUpper();
        string body = $"{name} - {dep ?? "OWNER"}";
        if(id == null) return body;
        else return $"[{id}] - {body}";
    }
}
