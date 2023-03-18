using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRunner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DROP TABLE IF EXISTS " +
                "`GroupSport`, `GroupUser`, `RefreshToken`, `Group`, `Sport`, `User`, `GroupType`, `SportType`, `UserRole`, " +
                "`WorkoutDetailByTime`, `WorkoutImage`, `WorkoutSummary`, `ViewPermissionType`;"
                );

            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.Sql(
                "CREATE TABLE `GroupType` (" +
                    "`GroupTypeId` int NOT NULL AUTO_INCREMENT," +
                    "`GroupTypeUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`GroupTypeName` enum('Company/Workplace', 'Racing Team', 'Club', 'Shop', 'Other') NOT NULL," +
                    "`CreatedBy` char(36) DEFAULT NULL," +
                    "`UpdatedBy` char(36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY (`GroupTypeId`)," +
                    "UNIQUE KEY `IX_GroupType_GroupTypeName` (`GroupTypeName`)" +
                ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;");

            migrationBuilder.Sql(
                "CREATE TABLE `SportType` (" +
                    "`SportTypeId` int NOT NULL AUTO_INCREMENT," +
                    "`SportTypeUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`SportTypeName` enum('Foot Sports','Cycle Sports','Water Sports','Winter Sports','Other Sports') NOT NULL," +
                    "`CreatedBy` char (36) DEFAULT NULL," +
                    "`UpdatedBy` char (36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY(`SportTypeId`)," +
                    "UNIQUE KEY `IX_SportType_SportTypeName` (`SportTypeName`)" +
                ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE = utf8mb4_0900_ai_ci");

            migrationBuilder.Sql(
                "CREATE TABLE `UserRole` (" +
                    "`UserRoleId` int NOT NULL AUTO_INCREMENT," +
                    "`UserRoleUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`RoleName` enum('Admin','Runner') NOT NULL," +
                    "`CreatedBy` char (36) DEFAULT NULL," +
                    "`UpdatedBy` char (36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY(`UserRoleId`)," +
                    "UNIQUE KEY `IX_UserRole_RoleName` (`RoleName`)" +
                ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE = utf8mb4_0900_ai_ci");

            migrationBuilder.Sql(
                "CREATE TABLE `ViewPermissionType` (" +
                    "`ViewPermissionTypeId` int NOT NULL AUTO_INCREMENT," +
                    "`ViewPermissionTypeUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`ViewPermission` enum('Everyone','Friends','Only me') NOT NULL," +
                    "`CreatedBy` char (36) DEFAULT NULL," +
                    "`UpdatedBy` char (36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY(`ViewPermissionTypeId`)," +
                    "UNIQUE KEY `IX_ViewPermissionType_ViewPermission` (`ViewPermission`)" +
                ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE = utf8mb4_0900_ai_ci;");

            migrationBuilder.Sql(
                "CREATE TABLE `Group` (" +
                    "`GroupId` int NOT NULL AUTO_INCREMENT," +
                    "`GroupUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`GroupImageUrl` varchar(225) DEFAULT NULL," +
                    "`GroupName` varchar(225) NOT NULL," +
                    "`Description` varchar(500) DEFAULT NULL," +
                    "`Website` varchar(225) DEFAULT NULL," +
                    "`Location` varchar(225) DEFAULT NULL," +
                    "`GroupTypeId` int NOT NULL," +
                    "`TotalRunner` int(6) NOT NULL," +
                    "`IsPublished` tinyint(1) NOT NULL DEFAULT 0," +
                    "`CreatedBy` char(36) DEFAULT NULL," +
                    "`UpdatedBy` char(36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY(`GroupId`)," +
                    "UNIQUE KEY `IX_Group_GroupName` (`GroupName`)," +
                    "KEY `IX_Group_GroupTypeId` (`GroupTypeId`)," +
                    "CONSTRAINT `FK_Group_GroupType_GroupTypeId` FOREIGN KEY(`GroupTypeId`) REFERENCES `GroupType` (`GroupTypeId`) ON DELETE CASCADE" +
                ") ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci; ");

            migrationBuilder.Sql(
                "CREATE TABLE `Sport` (" +
                "`SportId` int NOT NULL AUTO_INCREMENT," +
                "`SportUUId` char(36) NOT NULL DEFAULT (uuid())," +
                "`ImageUrl` varchar(225) DEFAULT NULL," +
                "`SportName` varchar(225) NOT NULL," +
                "`SportTypeId` int NOT NULL," +
                "`CreatedBy` char(36) DEFAULT NULL," +
                "`UpdatedBy` char(36) DEFAULT NULL," +
                "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                "`IsActive` tinyint(1) DEFAULT 1," +
                "`IsDeleted` tinyint(1) DEFAULT 0," +
                "PRIMARY KEY(`SportId`)," +
                "UNIQUE KEY `IX_Sport_SportName` (`SportName`)," +
                "KEY `IX_Sport_SportTypeId` (`SportTypeId`)," +
                "CONSTRAINT `FK_Sport_SportType_SportTypeId` FOREIGN KEY(`SportTypeId`) REFERENCES `SportType` (`SportTypeId`) ON DELETE CASCADE" +
                ") ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;");

            migrationBuilder.Sql(
                "CREATE TABLE `User` (" +
                    "`UserId` int NOT NULL AUTO_INCREMENT," +
                    "`UserUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`Email` varchar(225) NOT NULL," +
                    "`DisplayName` varchar(225) DEFAULT NULL," +
                    "`Birthday` datetime DEFAULT NULL," +
                    "`Gender` enum('NotToSay', 'Female', 'Male') DEFAULT 'NotToSay'," +
                    "`Height` int DEFAULT NULL," +
                    "`Weight` double DEFAULT NULL," +
                    "`ImageUrl` varchar(225) DEFAULT NULL," +
                    "`UserRoleId` int NOT NULL," +
                    "`IsRunner` tinyint(1) NOT NULL DEFAULT 1," +
                    "`PasswordHash` varchar(500) NOT NULL," +
                    "`CreatedBy` char(36) DEFAULT NULL," +
                    "`UpdatedBy` char(36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY(`UserId`)," +
                    "UNIQUE KEY `IX_User_Email_UserRoleId` (`Email`,`UserRoleId`)," +
                    "KEY `IX_User_UserRoleId` (`UserRoleId`)," +
                    "CONSTRAINT `FK_User_UserRole_UserRoleId` FOREIGN KEY(`UserRoleId`) REFERENCES `UserRole` (`UserRoleId`) ON DELETE CASCADE" +
                ") ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci");

            migrationBuilder.Sql(
                "CREATE TABLE `RefreshToken` (" +
                    "`RefreshTokenId` int NOT NULL AUTO_INCREMENT," +
                    "`RefreshTokenUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`Token` varchar(225) NOT NULL," +
                    "`Expires` datetime NOT NULL," +
                    "`CreatedByIp` char(50) NOT NULL," +
                    "`Revoked` datetime DEFAULT NULL," +
                    "`RevokedByIp` char(50) DEFAULT NULL," +
                    "`ReplacedByToken` varchar(225) DEFAULT NULL," +
                    "`ReasonRevoked` varchar(225) DEFAULT NULL," +
                    "`UserId` int NOT NULL," +
                    "`CreatedBy` char(36) DEFAULT NULL," +
                    "`UpdatedBy` char(36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY (`RefreshTokenId`)," +
                    "CONSTRAINT `FK_RefreshTokens_User_UserId` FOREIGN KEY(`UserId`) REFERENCES `User` (`UserId`) ON DELETE CASCADE" +
                ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;");

            migrationBuilder.Sql(
                "CREATE TABLE `WorkoutSummary` (" +
                    "`WorkoutSummaryId` int NOT NULL AUTO_INCREMENT," +
                    "`WorkoutSummaryUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`Title` varchar(225) NOT NULL," +
                    "`Description` varchar(500) DEFAULT NULL," +
                    "`Time` int(6) NOT NULL," +
                    "`Distance` double NOT NULL," +
                    "`AvgSpeed` double NOT NULL," +
                    "`StartTime` datetime NOT NULL," +
                    "`EndTime` datetime NOT NULL," +
                    "`UserRoleId` int NOT NULL," +
                    "`SportId` int NOT NULL," +
                    "`ViewPermissionTypeId` int NOT NULL," +
                    "`CreatedBy` char(36) DEFAULT NULL," +
                    "`UpdatedBy` char(36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY(`WorkoutSummaryId`)," +
                    "KEY `IX_WorkoutSummary_SportId` (`SportId`)," +
                    "KEY `IX_WorkoutSummary_UserRoleId` (`UserRoleId`)," +
                    "KEY `IX_WorkoutSummary_ViewPermissionTypeId` (`ViewPermissionTypeId`)," +
                    "CONSTRAINT `FK_WorkoutSummary_Sport_SportId` FOREIGN KEY(`SportId`) REFERENCES `Sport` (`SportId`) ON DELETE CASCADE," +
                    "CONSTRAINT `FK_WorkoutSummary_UserRole_UserRoleId` FOREIGN KEY(`UserRoleId`) REFERENCES `UserRole` (`UserRoleId`) ON DELETE CASCADE," +
                    "CONSTRAINT `FK_WorkoutSummary_ViewPermissionType_ViewPermissionTypeId` FOREIGN KEY(`ViewPermissionTypeId`) REFERENCES `ViewPermissionType` (`ViewPermissionTypeId`) ON DELETE CASCADE" +
                ") ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;");

            migrationBuilder.Sql(
                "CREATE TABLE `WorkoutDetailByTime` (" +
                    "`WorkoutDetailByTimeId` int NOT NULL AUTO_INCREMENT," +
                    "`WorkoutDetailByTimeUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`WorkoutDetailData` mediumtext NOT NULL," +
                    "`WorkoutSummaryId` int NOT NULL," +
                    "`CreatedBy` char(36) DEFAULT NULL," +
                    "`UpdatedBy` char(36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY(`WorkoutDetailByTimeId`)," +
                    "UNIQUE KEY `IX_WorkoutDetailByTime_WorkoutSummaryId` (`WorkoutSummaryId`)," +
                    "CONSTRAINT `FK_WorkoutDetailByTime_WorkoutSummary_WorkoutSummaryId` FOREIGN KEY(`WorkoutSummaryId`) REFERENCES `WorkoutSummary` (`WorkoutSummaryId`) ON DELETE CASCADE" +
                ") ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;");

            migrationBuilder.Sql(
                "CREATE TABLE `WorkoutImage` (" +
                    "`WorkoutImageId` int NOT NULL AUTO_INCREMENT," +
                    "`WorkoutImageUUId` char(36) NOT NULL DEFAULT (uuid())," +
                    "`WorkoutImageUrl` varchar(225) NOT NULL," +
                    "`WorkoutSummaryId` int NOT NULL," +
                    "`CreatedBy` char(36) DEFAULT NULL," +
                    "`UpdatedBy` char(36) DEFAULT NULL," +
                    "`CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP," +
                    "`UpdatedDate` datetime ON UPDATE CURRENT_TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
                    "`IsActive` tinyint(1) DEFAULT 1," +
                    "`IsDeleted` tinyint(1) DEFAULT 0," +
                    "PRIMARY KEY(`WorkoutImageId`)," +
                    "KEY `IX_WorkoutImage_WorkoutSummaryId` (`WorkoutSummaryId`)," +
                    "CONSTRAINT `FK_WorkoutImage_WorkoutSummary_WorkoutSummaryId` FOREIGN KEY(`WorkoutSummaryId`) REFERENCES `WorkoutSummary` (`WorkoutSummaryId`) ON DELETE CASCADE" +
                ") ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;");

            migrationBuilder.Sql(
                "CREATE TABLE `GroupSport` (" +
                    "`GroupsGroupId` int NOT NULL," +
                    "`SportsSportId` int NOT NULL," +
                    "PRIMARY KEY(`GroupsGroupId`,`SportsSportId`)," +
                    "KEY `IX_GroupSport_SportsSportId` (`SportsSportId`)," +
                    "CONSTRAINT `FK_GroupSport_Group_GroupsGroupId` FOREIGN KEY(`GroupsGroupId`) REFERENCES `Group` (`GroupId`) ON DELETE CASCADE," +
                    "CONSTRAINT `FK_GroupSport_Sport_SportsSportId` FOREIGN KEY(`SportsSportId`) REFERENCES `Sport` (`SportId`) ON DELETE CASCADE" +
                ") ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;");

            migrationBuilder.Sql(
                "CREATE TABLE `GroupUser` (" +
                    "`GroupsGroupId` int NOT NULL," +
                    "`UsersUserId` int NOT NULL," +
                    "PRIMARY KEY(`GroupsGroupId`,`UsersUserId`)," +
                    "CONSTRAINT `FK_GroupUser_Group_GroupsGroupId` FOREIGN KEY(`GroupsGroupId`) REFERENCES `Group` (`GroupId`) ON DELETE CASCADE," +
                    "CONSTRAINT `FK_GroupUser_User_UsersUserId` FOREIGN KEY(`UsersUserId`) REFERENCES `User` (`UserId`) ON DELETE CASCADE" +
                ") ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DROP TABLE IF EXISTS " +
                "`GroupSport`, `GroupUser`, `RefreshToken`, `Group`, `Sport`, `User`, `GroupType`, `SportType`, `UserRole`, " +
                "`WorkoutDetailByTime`, `WorkoutImage`, `WorkoutSummary`, `ViewPermissionType`;"
                );
        }
    }
}
