using FluentMigrator;

namespace Infrastructure.Migrations;
[Migration(2024121502)]
public class CreateAuthorTable:Migration
{
    public override void Up()
    {
        Create.Table("Authors").WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Country").AsString(50).Nullable();
    }

    public override void Down()
    {
        Delete.Table("Authors");
    }
}