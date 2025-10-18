namespace Infrastructure.Data;
public static class DbProviders
{
	public const string MSSQL = "MSSQL";
	public const string MSSQLASSEMBLY = "Migrations.SqlServer";

	public const string POSTGRESQL = "POSTGRESQL";
	public const string POSTGRESQLASSEMBLY = "Migrations.PostgreSQL";
}