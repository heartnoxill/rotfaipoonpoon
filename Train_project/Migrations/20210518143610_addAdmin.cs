using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Train_project.Migrations
{
    public partial class addAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogins",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogins", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    C_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_price = table.Column<int>(type: "int", nullable: false),
                    Aisle_no = table.Column<int>(type: "int", nullable: false),
                    Seat_no = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.C_id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    P_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.P_id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Promotion_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount_percent = table.Column<float>(type: "real", nullable: false),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Promotion_id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    R_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R_price = table.Column<int>(type: "int", nullable: false),
                    Departure_station = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departure_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departure_state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination_station = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination_state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.R_id);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    TR_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TR_age = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Maxspeed = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max_cap = table.Column<int>(type: "int", nullable: false),
                    Seats_filled = table.Column<int>(type: "int", nullable: false),
                    Seats_remain = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.TR_id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Q_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIn_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estimated_ToA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteR_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Q_id);
                    table.ForeignKey(
                        name: "FK_Schedules_Routes_RouteR_id",
                        column: x => x.RouteR_id,
                        principalTable: "Routes",
                        principalColumn: "R_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    ST_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ST_fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ST_lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ST_resp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ST_DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainTR_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ST_id);
                    table.ForeignKey(
                        name: "FK_Staffs_Trains_TrainTR_id",
                        column: x => x.TrainTR_id,
                        principalTable: "Trains",
                        principalColumn: "TR_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    T_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_issued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassengerP_id = table.Column<int>(type: "int", nullable: false),
                    TrainTR_id = table.Column<int>(type: "int", nullable: false),
                    ClassC_id = table.Column<int>(type: "int", nullable: false),
                    RouteR_id = table.Column<int>(type: "int", nullable: false),
                    ScheduleQ_id = table.Column<int>(type: "int", nullable: true),
                    PromotionPromotion_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.T_id);
                    table.ForeignKey(
                        name: "FK_Tickets_Class_ClassC_id",
                        column: x => x.ClassC_id,
                        principalTable: "Class",
                        principalColumn: "C_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerP_id",
                        column: x => x.PassengerP_id,
                        principalTable: "Passengers",
                        principalColumn: "P_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Promotions_PromotionPromotion_id",
                        column: x => x.PromotionPromotion_id,
                        principalTable: "Promotions",
                        principalColumn: "Promotion_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Routes_RouteR_id",
                        column: x => x.RouteR_id,
                        principalTable: "Routes",
                        principalColumn: "R_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Schedules_ScheduleQ_id",
                        column: x => x.ScheduleQ_id,
                        principalTable: "Schedules",
                        principalColumn: "Q_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Trains_TrainTR_id",
                        column: x => x.TrainTR_id,
                        principalTable: "Trains",
                        principalColumn: "TR_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RouteR_id",
                table: "Schedules",
                column: "RouteR_id");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_TrainTR_id",
                table: "Staffs",
                column: "TrainTR_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClassC_id",
                table: "Tickets",
                column: "ClassC_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerP_id",
                table: "Tickets",
                column: "PassengerP_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PromotionPromotion_id",
                table: "Tickets",
                column: "PromotionPromotion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RouteR_id",
                table: "Tickets",
                column: "RouteR_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScheduleQ_id",
                table: "Tickets",
                column: "ScheduleQ_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TrainTR_id",
                table: "Tickets",
                column: "TrainTR_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLogins");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
