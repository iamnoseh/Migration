using System.Data;
using FluentMigrator;

namespace Infrastructure.Migrations;
[Migration(2024122501)]
public class CreateBookTable: Migration
{
    public override void Up()
    {
        Create.Table("Books").WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(100).NotNullable()
            .WithColumn("AuthorId").AsInt32().NotNullable().ForeignKey("Authors","Id").OnDelete(Rule.Cascade)
            .WithColumn("Publisher").AsDateTime().WithDefault(SystemMethods.CurrentDateTime)
            .WithColumn("Genre").AsString(59).Nullable();
    }

    public override void Down()
    {
        Delete.Table("Books");
    }
}