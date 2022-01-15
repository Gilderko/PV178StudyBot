﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PV178StudyBotDAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointReward = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PointsRequired = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwardedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorR = table.Column<float>(type: "real", nullable: false),
                    ColorG = table.Column<float>(type: "real", nullable: false),
                    ColorB = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    OnRegisterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcquiredPoints = table.Column<int>(type: "int", nullable: false),
                    CurrentRankId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MyTeacherId = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Ranks_CurrentRankId",
                        column: x => x.CurrentRankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_MyTeacherId",
                        column: x => x.MyTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AchievmentId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Achievements_AchievmentId",
                        column: x => x.AchievmentId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAndAchievements",
                columns: table => new
                {
                    StudentId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AchievementId = table.Column<int>(type: "int", nullable: false),
                    ReceivedWhen = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAndAchievements", x => new { x.AchievementId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentAndAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAndAchievements_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "Description", "ImagePath", "Name", "PointReward" },
                values: new object[,]
                {
                    { 1, "Login into the achievement system.", null, "Good Start", 0 },
                    { 19, "Make a project presentation with nice slides.", null, "Leonardo", 0 },
                    { 18, "Present a complete project.", null, "Bullseye", 0 },
                    { 17, "Get a full score from a homework at least 3 times.", null, "Half-perfectionist", 0 },
                    { 16, "Submit fifth homework at least 2 days before the deadline and get at least 80% points.", null, "Fast Logger", 0 },
                    { 15, "Gain at least 90% points from the fourth homework.", null, "Shark Expert", 0 },
                    { 14, "In your third homework create additional song for the game and submit it with the homework.", null, "Mozart", 0 },
                    { 13, "Open and correctly answer all test questionnaires.", null, "Armed & Ready", 0 },
                    { 12, "Correctly answers at least 2 test questionnaires on the first attempt.", null, "Lucker", 0 },
                    { 20, "Get 54 points total.", null, "Skiller", 0 },
                    { 11, "Invited friend visited your seminar group.", null, "Recruiter", 0 },
                    { 9, "Do not arrive late to any seminar.", null, "Never Too Late", 0 },
                    { 8, "Do not arrive late to a seminar.", null, "Not Too Late", 0 },
                    { 7, "Visit 6 consecutive seminars.", null, "Fanatic", 0 },
                    { 6, "Create at least four unit tests in your homework.", null, "See Sharp", 0 },
                    { 5, "Write a relevant post in the discussion forum, or discord channel.", null, "Yes, We Have a Forum", 0 },
                    { 4, "First question in seminar.", null, "Curious", 0 },
                    { 3, "First answer to a relevant question in seminar.", null, "First Blood", 0 },
                    { 2, " Visit the third seminar.", null, "Qualifier", 0 },
                    { 10, "Visit another seminar group.", null, "Guest on a Quest", 0 }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: 317634903959142401m);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AchievmentId",
                table: "Requests",
                column: "AchievmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentId",
                table: "Requests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TeacherId",
                table: "Requests",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAndAchievements_StudentId",
                table: "StudentAndAchievements",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentRankId",
                table: "Students",
                column: "CurrentRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MyTeacherId",
                table: "Students",
                column: "MyTeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "StudentAndAchievements");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}