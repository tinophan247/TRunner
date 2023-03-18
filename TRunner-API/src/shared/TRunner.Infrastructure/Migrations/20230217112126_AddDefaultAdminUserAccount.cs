using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRunner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdminUserAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "SET @userRoleId = (SELECT UserRoleId FROM `UserRole` WHERE `RoleName` = 'Admin');" +
                "INSERT IGNORE INTO `User` (`Email`, `DisplayName`, `Birthday`, `Gender`, `UserRoleId`, `IsRunner`, `PasswordHash`) " +
                "VALUES('admin@oplus.com.vn', 'Admin', '1995-02-17 00:00:00', 'Male', @userRoleId, 0, '$2a$11$1QfCwbJGGhakttJ1DhZz6uqaUV5jqmk5C93Bw4sJKITX2NDZZvoL6');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE IGNORE FROM `User` WHERE `Email` = 'admin@oplus.com.vn';");
        }
    }
}
