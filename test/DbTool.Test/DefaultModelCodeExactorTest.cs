﻿using DbTool.Core;
using Xunit;

namespace DbTool.Test;

public class DefaultModelCodeExactorTest
{
    [Fact]
    public async Task GenerateCodeFromText()
    {
        var code = @"
public record Post
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime UpdatedAt { get; set; }
}
";
        var codeExactor = new DefaultCSharpModelCodeExactor(new DefaultModelNameConverter());
        var tables = await codeExactor.GetTablesFromSourceText(new DbProvider.SqlServer.SqlServerDbProvider(), code);
        Assert.NotNull(tables);
        Assert.NotEmpty(tables);
        Assert.Equal(4, tables[0].Columns.Count);
    }
}