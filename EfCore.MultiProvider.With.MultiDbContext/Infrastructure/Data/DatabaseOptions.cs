using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data;
public class DatabaseOptions
{
	public string Provider { get; set; } = "MSSQL";
	public string ConnectionString { get; set; } = string.Empty;
}
