using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRunner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT IGNORE INTO `GroupType` (`GroupTypeName`) VALUES('Company/Workplace'), ('Racing Team'), ('Club'), ('Shop'), ('Other');" +
                "INSERT IGNORE INTO `UserRole` (`RoleName`) VALUES ('Admin'), ('Runner');" +
                "INSERT IGNORE INTO `SportType` (`SportTypeName`) VALUES ('Foot Sports'), ('Cycle Sports'), ('Water Sports'), ('Winter Sports'), ('Other Sports');" +
                "INSERT IGNORE INTO `ViewPermissionType` (`ViewPermission`) VALUES ('Everyone'), ('Friends'), ('Only me');" +
                "");

            migrationBuilder.Sql(
                "SET @footSportId = (SELECT SportTypeId FROM `SportType` WHERE `SportTypeName` = 'Foot Sports');" +
                "SET @cycleSportId = (SELECT SportTypeId FROM `SportType` WHERE `SportTypeName` = 'Cycle Sports');" +
                "SET @waterSportId = (SELECT SportTypeId FROM `SportType` WHERE `SportTypeName` = 'Water Sports');" +
                "SET @winterSportId = (SELECT SportTypeId FROM `SportType` WHERE `SportTypeName` = 'Winter Sports');" +
                "SET @otherSportId = (SELECT SportTypeId FROM `SportType` WHERE `SportTypeName` = 'Other Sports');" +
                "INSERT IGNORE INTO `Sport` (`SportName`, `SportTypeId`, `IsActive`) " +
                "VALUES('Run', @footSportId, 1), ('Trail Run', @footSportId, 0), ('Walk', @footSportId, 1), ('Hike', @footSportId, 0), " +
                "('Ride', @cycleSportId, 1), ('Mountain Bike Ride', @cycleSportId, 0), ('Gravel Ride', @cycleSportId, 0), " +
                "('E-Bike Ride', @cycleSportId, 0), ('E-Mountain Bike Ride', @cycleSportId, 0), ('Velomobile Ride', @cycleSportId, 0), " +
                "('Canoe', @waterSportId, 0), ('Kayak', @waterSportId, 0), ('Kitesurf Session', @waterSportId, 0), ('Row', @waterSportId, 0), ('Sail', @waterSportId, 0), " +
                "('Stand Up Paddle', @waterSportId, 0), ('Surf', @waterSportId, 0), ('Swin', @waterSportId, 0), ('Windsurf Session', @waterSportId, 0), " +
                "('Ice Skate', @winterSportId, 0), ('Alpine Ski', @winterSportId, 0), ('Backcountry Ski', @winterSportId, 0), " +
                "('Nordic Ski', @winterSportId, 0), ('Snowboard', @winterSportId, 0), ('Snowshoe', @winterSportId, 0), " +
                "('Handcycle', @otherSportId, 0), ('Incline Skate', @otherSportId, 0), ('Rock Climb', @otherSportId, 0), ('Roller Ski', @otherSportId, 0), ('Golf', @otherSportId, 0), " +
                "('Skateboard', @otherSportId, 0), ('Football (Soccer)', @otherSportId, 0), ('Wheelchair', @otherSportId, 0), ('CrossFit', @otherSportId, 0), ('Elliptical', @otherSportId, 0), " +
                "('Stair Stepper', @otherSportId, 0), ('Weight Trainig', @otherSportId, 0), ('Yoga', @otherSportId, 0), ('Workout', @otherSportId, 0);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE IGNORE FROM `Sport`;" +
                "DELETE IGNORE FROM `GroupType`;" +
                "DELETE IGNORE FROM `UserRole`;" +
                "DELETE IGNORE FROM `SportType`;" +
                "DELETE IGNORE FROM `ViewPermissionType`;");
        }
    }
}
