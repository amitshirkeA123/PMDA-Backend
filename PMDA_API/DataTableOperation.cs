
using Newtonsoft.Json;
using PMDA_API.Controllers;
using PMDA_API.Models;
using System.Data;

namespace PMDA_API
{
    public static class DataTableOperation
    {
        private static readonly ILogger<WeatherForecastController> _logger;
        //public static async Task<List<MasterPMDARecords>> GetMasterRecords(DataTable dt_Datatable)
        //{
        //    List<MasterPMDARecords> lstMasterData = new List<MasterPMDARecords>();
        //    try
        //    {
        //        for (int i = 0; i < dt_Datatable.Rows.Count; i++)
        //        {
        //            MasterPMDARecords objMasterData = new MasterPMDARecords();
        //            objMasterData.UTC_Time = (TimeSpan)dt_Datatable.Rows[i]["UTC_Time"];
        //            objMasterData.Threat_count = Convert.IsDBNull(dt_Datatable.Rows[i]["Threat_count"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Threat_count"]);

        //            #region Threat Details
        //            objMasterData.Threat_1_Threat_Presence = dt_Datatable.Rows[i]["Threat_1__Threat_Presence"]?.ToString();
        //            objMasterData.Threat_1_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_1__Threat_symbol_code"]?.ToString();
        //            objMasterData.Threat_1_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_1__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_1__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_1__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_1__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_1__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_1__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_1__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_1__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_1__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_1__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_1__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_circle_Attribute = dt_Datatable.Rows[i]["Threat_1__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Square_Attribute = dt_Datatable.Rows[i]["Threat_1__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_1__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_1__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Display_status = dt_Datatable.Rows[i]["Threat_1__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_Blink_status = dt_Datatable.Rows[i]["Threat_1__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_1_MDT_status = dt_Datatable.Rows[i]["Threat_1__MDT_status"]?.ToString() ?? string.Empty;

        //            objMasterData.Threat_2_Threat_Presence = dt_Datatable.Rows[i]["Threat_2__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_2__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_2__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_2__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_2__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_2__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_2__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_2__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_2__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_2__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_2__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_2__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_2__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_circle_Attribute = dt_Datatable.Rows[i]["Threat_2__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Square_Attribute = dt_Datatable.Rows[i]["Threat_2__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_2__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_2__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Display_status = dt_Datatable.Rows[i]["Threat_2__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_Blink_status = dt_Datatable.Rows[i]["Threat_1__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_2_MDT_status = dt_Datatable.Rows[i]["Threat_1__MDT_status"]?.ToString() ?? string.Empty;


        //            objMasterData.Threat_3_Threat_Presence = dt_Datatable.Rows[i]["Threat_3__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_3__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_3__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_3__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_3__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_circle_Attribute = dt_Datatable.Rows[i]["Threat_3__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Square_Attribute = dt_Datatable.Rows[i]["Threat_3__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_3__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_3__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Display_status = dt_Datatable.Rows[i]["Threat_3__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_Blink_status = dt_Datatable.Rows[i]["Threat_3__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_3_MDT_status = dt_Datatable.Rows[i]["Threat_3__MDT_status"]?.ToString() ?? string.Empty;

        //            objMasterData.Threat_4_Threat_Presence = dt_Datatable.Rows[i]["Threat_3__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_3__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_3__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_3__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_3__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_3__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_circle_Attribute = dt_Datatable.Rows[i]["Threat_3__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Square_Attribute = dt_Datatable.Rows[i]["Threat_3__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_3__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_3__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Display_status = dt_Datatable.Rows[i]["Threat_3__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_Blink_status = dt_Datatable.Rows[i]["Threat_3__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_4_MDT_status = dt_Datatable.Rows[i]["Threat_3__MDT_status"]?.ToString() ?? string.Empty;

        //            objMasterData.Threat_5_Threat_Presence = dt_Datatable.Rows[i]["Threat_5__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_5__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_5__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_5__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_5__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_5__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_5__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_5__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_5__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_5__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_5__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_5__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_5__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_circle_Attribute = dt_Datatable.Rows[i]["Threat_5__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Square_Attribute = dt_Datatable.Rows[i]["Threat_5__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_5__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_5__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Display_status = dt_Datatable.Rows[i]["Threat_5__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_Blink_status = dt_Datatable.Rows[i]["Threat_5__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_5_MDT_status = dt_Datatable.Rows[i]["Threat_5__MDT_status"]?.ToString() ?? string.Empty;



        //            objMasterData.Threat_6_Threat_Presence = dt_Datatable.Rows[i]["Threat_6__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_6__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_6__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_6__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_6__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_6__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_6__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_6__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_6__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_6__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_6__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_6__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_6__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_circle_Attribute = dt_Datatable.Rows[i]["Threat_6__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Square_Attribute = dt_Datatable.Rows[i]["Threat_6__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_6__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_6__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Display_status = dt_Datatable.Rows[i]["Threat_6__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_Blink_status = dt_Datatable.Rows[i]["Threat_6__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_6_MDT_status = dt_Datatable.Rows[i]["Threat_6__MDT_status"]?.ToString() ?? string.Empty;


        //            objMasterData.Threat_7_Threat_Presence = dt_Datatable.Rows[i]["Threat_7__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_7__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_7__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_7__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_7__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_7__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_7__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_7__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_7__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_7__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_7__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_7__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_7__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_circle_Attribute = dt_Datatable.Rows[i]["Threat_7__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Square_Attribute = dt_Datatable.Rows[i]["Threat_7__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_7__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_7__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Display_status = dt_Datatable.Rows[i]["Threat_7__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_Blink_status = dt_Datatable.Rows[i]["Threat_7__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_7_MDT_status = dt_Datatable.Rows[i]["Threat_7__MDT_status"]?.ToString() ?? string.Empty;

        //            objMasterData.Threat_8_Threat_Presence = dt_Datatable.Rows[i]["Threat_8__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_8__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_8__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_8__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_8__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_8__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_8__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_8__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_8__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_8__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_8__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_8__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_8__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_circle_Attribute = dt_Datatable.Rows[i]["Threat_8__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Square_Attribute = dt_Datatable.Rows[i]["Threat_8__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_8__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_8__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Display_status = dt_Datatable.Rows[i]["Threat_8__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_Blink_status = dt_Datatable.Rows[i]["Threat_8__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_8_MDT_status = dt_Datatable.Rows[i]["Threat_8__MDT_status"]?.ToString() ?? string.Empty;


        //            objMasterData.Threat_9_Threat_Presence = dt_Datatable.Rows[i]["Threat_9__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_9__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_9__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_9__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_9__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_9__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_9__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_9__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_9__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_9__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_9__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_9__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_9__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_circle_Attribute = dt_Datatable.Rows[i]["Threat_9__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Square_Attribute = dt_Datatable.Rows[i]["Threat_9__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_9__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_9__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Display_status = dt_Datatable.Rows[i]["Threat_9__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_Blink_status = dt_Datatable.Rows[i]["Threat_9__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_9_MDT_status = dt_Datatable.Rows[i]["Threat_9__MDT_status"]?.ToString() ?? string.Empty;


        //            objMasterData.Threat_10_Threat_Presence = dt_Datatable.Rows[i]["Threat_10__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_10__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_10__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_10__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_10__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_10__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_10__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_10__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_10__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_10__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_10__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_10__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_10__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_circle_Attribute = dt_Datatable.Rows[i]["Threat_10__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Square_Attribute = dt_Datatable.Rows[i]["Threat_10__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_10__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_10__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Display_status = dt_Datatable.Rows[i]["Threat_10__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_Blink_status = dt_Datatable.Rows[i]["Threat_10__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_10_MDT_status = dt_Datatable.Rows[i]["Threat_10__MDT_status"]?.ToString() ?? string.Empty;

        //            objMasterData.Threat_11_Threat_Presence = dt_Datatable.Rows[i]["Threat_11__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_11__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_11__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_11__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_11__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_11__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_11__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_11__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_11__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_11__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_11__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_11__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_11__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_circle_Attribute = dt_Datatable.Rows[i]["Threat_11__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Square_Attribute = dt_Datatable.Rows[i]["Threat_11__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_11__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_11__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Display_status = dt_Datatable.Rows[i]["Threat_11__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_Blink_status = dt_Datatable.Rows[i]["Threat_11__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_11_MDT_status = dt_Datatable.Rows[i]["Threat_11__MDT_status"]?.ToString() ?? string.Empty;

        //            objMasterData.Threat_12_Threat_Presence = dt_Datatable.Rows[i]["Threat_11__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_11__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_12__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_12__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_12__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_12__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_12__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_12__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_12__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_12__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_12__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_12__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_12__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_circle_Attribute = dt_Datatable.Rows[i]["Threat_12__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Square_Attribute = dt_Datatable.Rows[i]["Threat_12__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_12__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_12__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Display_status = dt_Datatable.Rows[i]["Threat_12__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_Blink_status = dt_Datatable.Rows[i]["Threat_12__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_12_MDT_status = dt_Datatable.Rows[i]["Threat_12__MDT_status"]?.ToString() ?? string.Empty;


        //            objMasterData.Threat_13_Threat_Presence = dt_Datatable.Rows[i]["Threat_13__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_13__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_13__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_13__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_13__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_13__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_13__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_13__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_13__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_13__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_13__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_13__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_13__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_circle_Attribute = dt_Datatable.Rows[i]["Threat_13__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Square_Attribute = dt_Datatable.Rows[i]["Threat_13__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_13__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_13__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Display_status = dt_Datatable.Rows[i]["Threat_13__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_Blink_status = dt_Datatable.Rows[i]["Threat_13__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_13_MDT_status = dt_Datatable.Rows[i]["Threat_13__MDT_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Presence = dt_Datatable.Rows[i]["Threat_14__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_14__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_14__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_14__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_14__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_14__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_14__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_14__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_14__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_14__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_14__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_14__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_14__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_circle_Attribute = dt_Datatable.Rows[i]["Threat_14__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Square_Attribute = dt_Datatable.Rows[i]["Threat_14__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_14__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_14__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Display_status = dt_Datatable.Rows[i]["Threat_14__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_Blink_status = dt_Datatable.Rows[i]["Threat_14__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_14_MDT_status = dt_Datatable.Rows[i]["Threat_14__MDT_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Presence = dt_Datatable.Rows[i]["Threat_15__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_15__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_15__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_15__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_15__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_15__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_15__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_15__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_15__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_15__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_15__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_15__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_15__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_circle_Attribute = dt_Datatable.Rows[i]["Threat_15__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Square_Attribute = dt_Datatable.Rows[i]["Threat_15__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_15__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_15__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Display_status = dt_Datatable.Rows[i]["Threat_15__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_Blink_status = dt_Datatable.Rows[i]["Threat_15__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_15_MDT_status = dt_Datatable.Rows[i]["Threat_15__MDT_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Presence = dt_Datatable.Rows[i]["Threat_16__Threat_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_symbolcode = dt_Datatable.Rows[i]["Threat_16__Threat_symbol_code"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Alt_symbolcode = dt_Datatable.Rows[i]["Threat_16__Threat_Alt_symbolcode"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Name_Char1 = dt_Datatable.Rows[i]["Threat_16__Threat_Name_Char1"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Name_Char2 = dt_Datatable.Rows[i]["Threat_16__Threat_Name_Char2"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Name_Char3 = dt_Datatable.Rows[i]["Threat_16__Threat_Name_Char3"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Name_Char4 = dt_Datatable.Rows[i]["Threat_16__Threat_Name_Char4"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Name_Char5 = dt_Datatable.Rows[i]["Threat_16__Threat_Name_Char5"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Name_Char6 = dt_Datatable.Rows[i]["Threat_16__Threat_Name_Char6"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Name_Char7 = dt_Datatable.Rows[i]["Threat_16__Threat_Name_Char7"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_Name_Char8 = dt_Datatable.Rows[i]["Threat_16__Threat_Name_Char8"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threat_sym_FG_colour = dt_Datatable.Rows[i]["Threat_16__Threat_sym_FG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Threatsym_BG_colour = dt_Datatable.Rows[i]["Threat_16__Threatsym_BG_colour"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_circle_Attribute = dt_Datatable.Rows[i]["Threat_16__circle_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Square_Attribute = dt_Datatable.Rows[i]["Threat_16__Square_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Moustache_Attribute = dt_Datatable.Rows[i]["Threat_16__Moustache_Attribute"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Diamond_Attribure = dt_Datatable.Rows[i]["Threat_16__Diamond_Attribure"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Display_status = dt_Datatable.Rows[i]["Threat_16__Display_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_Blink_status = dt_Datatable.Rows[i]["Threat_16__Blink_status"]?.ToString() ?? string.Empty;
        //            objMasterData.Threat_16_MDT_status = dt_Datatable.Rows[i]["Threat_16__MDT_status"]?.ToString() ?? string.Empty;
        //            #endregion


        //            #region Nav Details
        //            objMasterData.INS_PARAM_VALID = dt_Datatable.Rows[i]["INS_PARAM_VALID"]?.ToString() ?? string.Empty;
        //            objMasterData.BARO_Altitude_Valid = dt_Datatable.Rows[i]["BARO_Altitude_Valid"]?.ToString() ?? string.Empty;
        //            objMasterData.Radio_HT_Valid = dt_Datatable.Rows[i]["Radio_HT_Valid"]?.ToString() ?? string.Empty;
        //            objMasterData.GPS_Data_Valid = dt_Datatable.Rows[i]["GPS_Data_Valid"]?.ToString() ?? string.Empty;
        //            objMasterData.AC_On_Ground_Status = dt_Datatable.Rows[i]["AC_On_Ground_Status"]?.ToString() ?? string.Empty;
        //            objMasterData.Cmda_Presence = dt_Datatable.Rows[i]["Cmda_Presence"]?.ToString() ?? string.Empty;
        //            objMasterData.True_Heading = Convert.IsDBNull(dt_Datatable.Rows[i]["True_Heading"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["True_Heading"]);
        //            objMasterData.Pitch_Angle = Convert.IsDBNull(dt_Datatable.Rows[i]["Pitch_Angle"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Pitch_Angle"]);
        //            objMasterData.Roll_Angle = Convert.IsDBNull(dt_Datatable.Rows[i]["Roll_Angle"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Roll_Angle"]);
        //            objMasterData.X_Velocity = Convert.IsDBNull(dt_Datatable.Rows[i]["X_Velocity"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["X_Velocity"]);
        //            objMasterData.Y_Velocity = Convert.IsDBNull(dt_Datatable.Rows[i]["Y_Velocity"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Y_Velocity"]);
        //            objMasterData.Z_Velocity = Convert.IsDBNull(dt_Datatable.Rows[i]["Z_Velocity"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Z_Velocity"]);
        //            objMasterData.Pitch_Rate = Convert.IsDBNull(dt_Datatable.Rows[i]["Pitch_Rate"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Pitch_Rate"]);
        //            objMasterData.Roll_Rate = Convert.IsDBNull(dt_Datatable.Rows[i]["Roll_Rate"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Roll_Rate"]);
        //            objMasterData.Yaw_Rate = Convert.IsDBNull(dt_Datatable.Rows[i]["Yaw_Rate"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Yaw_Rate"]);
        //            objMasterData.Radio_Height = Convert.IsDBNull(dt_Datatable.Rows[i]["Radio_Height"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Radio_Height"]);
        //            objMasterData.BARO_Altitude = Convert.IsDBNull(dt_Datatable.Rows[i]["BARO_Altitude"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["BARO_Altitude"]);
        //            objMasterData.GPS_Day = Convert.IsDBNull(dt_Datatable.Rows[i]["GPS_Day"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["GPS_Day"]);
        //            objMasterData.GPS_Hour = Convert.IsDBNull(dt_Datatable.Rows[i]["GPS_Hour"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["GPS_Hour"]);
        //            objMasterData.GPS_Minute = Convert.IsDBNull(dt_Datatable.Rows[i]["GPS_Minute"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["GPS_Minute"]);
        //            objMasterData.GPS_Seconds = Convert.IsDBNull(dt_Datatable.Rows[i]["GPS_Seconds"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["GPS_Seconds"]);
        //            objMasterData.Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Latitude"]);
        //            objMasterData.Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Longitude"]);
        //            objMasterData.Altitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Altitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Altitude"]);
        //            objMasterData.YAW_Angle = Convert.IsDBNull(dt_Datatable.Rows[i]["YAW_Angle"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["YAW_Angle"]);
        //            objMasterData.Emitter_Count = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter_Count"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter_Count"]);

        //            objMasterData.Emitter1_Name = dt_Datatable.Rows[i]["Emitter1_Name"]?.ToString();
        //            objMasterData.Emitter1_Type = dt_Datatable.Rows[i]["Emitter1_Type"]?.ToString();

        //            objMasterData.Emitter1_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter1_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter1_Latitude"]);
        //            objMasterData.Emitter1_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter1_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter1_Longitude"]);


        //            objMasterData.Emitter1_SymbolCode = dt_Datatable.Rows[i]["Emitter1_SymbolCode"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter1_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter1_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter1_Azimuth"]);
        //            objMasterData.Emitter1_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter1_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter1_LethalUnit"]);
        //            objMasterData.Emitter1_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter1_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter1_Range"]);


        //            objMasterData.Emitter2_Name = dt_Datatable.Rows[i]["Emitter2_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter2_Type = dt_Datatable.Rows[i]["Emitter2_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter2_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter2_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter2_Latitude"]);
        //            objMasterData.Emitter2_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter2_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter2_Longitude"]);

        //            objMasterData.Emitter2_SymbolCode = dt_Datatable.Rows[i]["Emitter2_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter2_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter2_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter2_Azimuth"]);
        //            objMasterData.Emitter2_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter2_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter2_LethalUnit"]);
        //            objMasterData.Emitter2_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter2_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter2_Range"]);


        //            objMasterData.Emitter3_Name = dt_Datatable.Rows[i]["Emitter3_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter3_Type = dt_Datatable.Rows[i]["Emitter3_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter3_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter3_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter3_Latitude"]);
        //            objMasterData.Emitter3_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter3_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter3_Longitude"]);


        //            objMasterData.Emitter3_SymbolCode = dt_Datatable.Rows[i]["Emitter3_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter3_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter3_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter3_Azimuth"]);
        //            objMasterData.Emitter3_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter3_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter3_LethalUnit"]);
        //            objMasterData.Emitter3_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter3_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter3_Range"]);

        //            objMasterData.Emitter4_Name = dt_Datatable.Rows[i]["Emitter4_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter4_Type = dt_Datatable.Rows[i]["Emitter4_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter4_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter4_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter4_Latitude"]);
        //            objMasterData.Emitter4_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter4_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter4_Longitude"]);


        //            objMasterData.Emitter4_SymbolCode = dt_Datatable.Rows[i]["Emitter4_SymbolCode"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter4_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter4_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter4_Azimuth"]);
        //            objMasterData.Emitter4_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter4_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter4_LethalUnit"]);
        //            objMasterData.Emitter4_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter4_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter4_Range"]);


        //            objMasterData.Emitter5_Name = dt_Datatable.Rows[i]["Emitter5_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter5_Type = dt_Datatable.Rows[i]["Emitter5_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter5_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter5_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter5_Latitude"]);
        //            objMasterData.Emitter5_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter5_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter5_Longitude"]);


        //            objMasterData.Emitter5_SymbolCode = dt_Datatable.Rows[i]["Emitter5_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter5_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter5_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter5_Azimuth"]);
        //            objMasterData.Emitter5_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter5_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter5_LethalUnit"]);
        //            objMasterData.Emitter5_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter5_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter5_Range"]);


        //            objMasterData.Emitter6_Name = dt_Datatable.Rows[i]["Emitter6_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter6_Type = dt_Datatable.Rows[i]["Emitter6_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter6_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter6_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter6_Latitude"]);
        //            objMasterData.Emitter6_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter6_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter6_Longitude"]);

        //            objMasterData.Emitter6_SymbolCode = dt_Datatable.Rows[i]["Emitter6_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter6_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter6_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter6_Azimuth"]);
        //            objMasterData.Emitter6_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter6_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter6_LethalUnit"]);
        //            objMasterData.Emitter6_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter6_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter6_Range"]);


        //            objMasterData.Emitter7_Name = dt_Datatable.Rows[i]["Emitter7_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter7_Type = dt_Datatable.Rows[i]["Emitter7_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter7_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter7_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter7_Latitude"]);
        //            objMasterData.Emitter7_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter7_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter7_Longitude"]);


        //            objMasterData.Emitter7_SymbolCode = dt_Datatable.Rows[i]["Emitter7_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter7_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter7_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter7_Azimuth"]);
        //            objMasterData.Emitter7_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter7_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter7_LethalUnit"]);
        //            objMasterData.Emitter7_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter7_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter7_Range"]);


        //            objMasterData.Emitter8_Name = dt_Datatable.Rows[i]["Emitter8_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter8_Type = dt_Datatable.Rows[i]["Emitter8_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter8_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter8_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter8_Latitude"]);
        //            objMasterData.Emitter8_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter8_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter8_Longitude"]);

        //            objMasterData.Emitter8_SymbolCode = dt_Datatable.Rows[i]["Emitter8_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter8_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter8_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter8_Azimuth"]);
        //            objMasterData.Emitter8_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter8_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter8_LethalUnit"]);
        //            objMasterData.Emitter8_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter8_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter8_Range"]);


        //            objMasterData.Emitter9_Name = dt_Datatable.Rows[i]["Emitter9_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter9_Type = dt_Datatable.Rows[i]["Emitter9_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter9_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter9_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter9_Latitude"]);
        //            objMasterData.Emitter9_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter9_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter9_Longitude"]);

        //            objMasterData.Emitter9_SymbolCode = dt_Datatable.Rows[i]["Emitter9_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter9_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter9_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter9_Azimuth"]);
        //            objMasterData.Emitter9_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter9_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter9_LethalUnit"]);
        //            objMasterData.Emitter9_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter9_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter9_Range"]);


        //            objMasterData.Emitter10_Name = dt_Datatable.Rows[i]["Emitter10_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter10_Type = dt_Datatable.Rows[i]["Emitter10_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter10_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter10_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter10_Latitude"]);
        //            objMasterData.Emitter10_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter10_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter10_Longitude"]);

        //            objMasterData.Emitter10_SymbolCode = dt_Datatable.Rows[i]["Emitter10_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter10_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter10_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter10_Azimuth"]);
        //            objMasterData.Emitter10_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter10_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter10_LethalUnit"]);
        //            objMasterData.Emitter10_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter10_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter10_Range"]);



        //            objMasterData.Emitter11_Name = dt_Datatable.Rows[i]["Emitter11_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter11_Type = dt_Datatable.Rows[i]["Emitter11_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter11_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter11_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter11_Latitude"]);
        //            objMasterData.Emitter11_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter11_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter11_Longitude"]);
                    

        //             objMasterData.Emitter11_SymbolCode = dt_Datatable.Rows[i]["Emitter11_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter11_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter11_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter11_Azimuth"]);
        //            objMasterData.Emitter11_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter11_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter11_LethalUnit"]);
        //            objMasterData.Emitter11_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter11_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter11_Range"]);


        //            objMasterData.Emitter12_Name = dt_Datatable.Rows[i]["Emitter12_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter12_Type = dt_Datatable.Rows[i]["Emitter12_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter12_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter12_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter12_Latitude"]);
        //            objMasterData.Emitter12_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter12_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter12_Longitude"]);

        //            objMasterData.Emitter12_SymbolCode = dt_Datatable.Rows[i]["Emitter12_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter12_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter12_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter12_Azimuth"]);
        //            objMasterData.Emitter12_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter12_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter12_LethalUnit"]);
        //            objMasterData.Emitter12_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter12_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter12_Range"]);

        //            objMasterData.Emitter13_Name = dt_Datatable.Rows[i]["Emitter13_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter13_Type = dt_Datatable.Rows[i]["Emitter13_Type"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter13_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter13_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter13_Latitude"]);
        //            objMasterData.Emitter13_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter13_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter13_Longitude"]);

        //            objMasterData.Emitter13_SymbolCode = dt_Datatable.Rows[i]["Emitter13_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter13_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter13_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter13_Azimuth"]);
        //            objMasterData.Emitter13_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter13_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter13_LethalUnit"]);
        //            objMasterData.Emitter13_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter13_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter13_Range"]);

        //            objMasterData.Emitter14_Name = dt_Datatable.Rows[i]["Emitter14_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter14_Type = dt_Datatable.Rows[i]["Emitter14_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter14_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter14_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter14_Latitude"]);
        //            objMasterData.Emitter14_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter14_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter14_Longitude"]);

        //            objMasterData.Emitter14_SymbolCode = dt_Datatable.Rows[i]["Emitter14_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter14_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter14_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter14_Azimuth"]);
        //            objMasterData.Emitter14_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter14_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter14_LethalUnit"]);
        //            objMasterData.Emitter14_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter14_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter14_Range"]);

        //            objMasterData.Emitter15_Name = dt_Datatable.Rows[i]["Emitter15_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter15_Type = dt_Datatable.Rows[i]["Emitter15_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter15_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter15_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter15_Latitude"]);
        //            objMasterData.Emitter15_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter15_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter15_Longitude"]);

        //            objMasterData.Emitter15_SymbolCode = dt_Datatable.Rows[i]["Emitter15_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter15_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter15_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter15_Azimuth"]);
        //            objMasterData.Emitter15_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter15_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter15_LethalUnit"]);
        //            objMasterData.Emitter15_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter15_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter15_Range"]);



        //            objMasterData.Emitter16_Name = dt_Datatable.Rows[i]["Emitter16_Name"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter16_Type = dt_Datatable.Rows[i]["Emitter16_Type"]?.ToString() ?? string.Empty;

        //            objMasterData.Emitter16_Latitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter16_Latitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter16_Latitude"]);
        //            objMasterData.Emitter16_Longitude = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter16_Longitude"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Emitter16_Longitude"]);

        //            objMasterData.Emitter16_SymbolCode = dt_Datatable.Rows[i]["Emitter16_SymbolCode"]?.ToString() ?? string.Empty;
        //            objMasterData.Emitter16_Azimuth = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter16_Azimuth"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter16_Azimuth"]);
        //            objMasterData.Emitter16_LethalUnit = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter16_LethalUnit"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter16_LethalUnit"]);
        //            objMasterData.Emitter16_Range = Convert.IsDBNull(dt_Datatable.Rows[i]["Emitter16_Range"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Emitter16_Range"]);

        //            #endregion

        //            objMasterData.TRACK_ID = Convert.IsDBNull(dt_Datatable.Rows[i]["TRACK_ID"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["TRACK_ID"]);
        //            objMasterData.HIT_count = Convert.IsDBNull(dt_Datatable.Rows[i]["HIT_count"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["HIT_count"]);
        //            objMasterData.Symbol_code = Convert.IsDBNull(dt_Datatable.Rows[i]["Symbol_code"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Symbol_code"]);
        //            objMasterData.Frequency_MHZ = Convert.IsDBNull(dt_Datatable.Rows[i]["Frequency_MHZ"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Frequency_MHZ"]);
        //            objMasterData.Pulsewidth_us = Convert.IsDBNull(dt_Datatable.Rows[i]["Pulsewidth_us"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Pulsewidth_us"]);
        //            objMasterData.Amplitude_dBm = Convert.IsDBNull(dt_Datatable.Rows[i]["Amplitude_dBm"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Amplitude_dBm"]);
        //            objMasterData.AOA_deg = Convert.IsDBNull(dt_Datatable.Rows[i]["AOA_deg"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["AOA_deg"]);
        //            objMasterData.DOA_deg = Convert.IsDBNull(dt_Datatable.Rows[i]["DOA_deg"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["DOA_deg"]);
        //            objMasterData.Lattitude_Deg = Convert.IsDBNull(dt_Datatable.Rows[i]["Lattitude_Deg"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Lattitude_Deg"]);
        //            objMasterData.Longitude_Deg = Convert.IsDBNull(dt_Datatable.Rows[i]["Longitude_Deg"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Longitude_Deg"]);
        //            objMasterData.TrueHeading_Deg = Convert.IsDBNull(dt_Datatable.Rows[i]["TrueHeading_Deg"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["TrueHeading_Deg"]);
        //            objMasterData.Altitude_m = Convert.IsDBNull(dt_Datatable.Rows[i]["Altitude_m"]) ? 0 : Convert.ToInt32(dt_Datatable.Rows[i]["Altitude_m"]);
        //            objMasterData.Roll_Deg = Convert.IsDBNull(dt_Datatable.Rows[i]["Roll_Deg"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Roll_Deg"]);
        //            objMasterData.Yaw_Deg = Convert.IsDBNull(dt_Datatable.Rows[i]["Yaw_Deg"]) ? 0m : Convert.ToDecimal(dt_Datatable.Rows[i]["Yaw_Deg"]);
        //            objMasterData.WeaponId = dt_Datatable.Rows[i]["WeaponId"]?.ToString() ?? string.Empty;
        //            objMasterData.WeaponDescription = dt_Datatable.Rows[i]["WeaponDescription"]?.ToString() ?? string.Empty;
        //            objMasterData.EmitterId = dt_Datatable.Rows[i]["EmitterId"]?.ToString() ?? string.Empty;
        //            objMasterData.EmitterDescription = dt_Datatable.Rows[i]["EmitterDescription"]?.ToString() ?? string.Empty;
        //            objMasterData.ModeId = dt_Datatable.Rows[i]["ModeId"]?.ToString() ?? string.Empty;
        //            objMasterData.ModeDescription = dt_Datatable.Rows[i]["ModeDescription"]?.ToString() ?? string.Empty;
        //            objMasterData.EmitterRange_Km = dt_Datatable.Rows[i]["EmitterRange_Km"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_1 = dt_Datatable.Rows[i]["PRI_1"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_2 = dt_Datatable.Rows[i]["PRI_2"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_3 = dt_Datatable.Rows[i]["PRI_3"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_4 = dt_Datatable.Rows[i]["PRI_4"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_5 = dt_Datatable.Rows[i]["PRI_5"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_6 = dt_Datatable.Rows[i]["PRI_6"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_7 = dt_Datatable.Rows[i]["PRI_7"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_8 = dt_Datatable.Rows[i]["PRI_8"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_9 = dt_Datatable.Rows[i]["PRI_9"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_10 = dt_Datatable.Rows[i]["PRI_10"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_11 = dt_Datatable.Rows[i]["PRI_11"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_12 = dt_Datatable.Rows[i]["PRI_12"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_13 = dt_Datatable.Rows[i]["PRI_13"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_14 = dt_Datatable.Rows[i]["PRI_14"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_15 = dt_Datatable.Rows[i]["PRI_15"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_16 = dt_Datatable.Rows[i]["PRI_16"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_17 = dt_Datatable.Rows[i]["PRI_17"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_18 = dt_Datatable.Rows[i]["PRI_18"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_19 = dt_Datatable.Rows[i]["PRI_19"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_20 = dt_Datatable.Rows[i]["PRI_20"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_21 = dt_Datatable.Rows[i]["PRI_21"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_22 = dt_Datatable.Rows[i]["PRI_22"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_23 = dt_Datatable.Rows[i]["PRI_23"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_24 = dt_Datatable.Rows[i]["PRI_24"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_25 = dt_Datatable.Rows[i]["PRI_25"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_26 = dt_Datatable.Rows[i]["PRI_26"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_27 = dt_Datatable.Rows[i]["PRI_27"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_28 = dt_Datatable.Rows[i]["PRI_28"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_29 = dt_Datatable.Rows[i]["PRI_29"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_30 = dt_Datatable.Rows[i]["PRI_30"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_31 = dt_Datatable.Rows[i]["PRI_31"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_32 = dt_Datatable.Rows[i]["PRI_32"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_33 = dt_Datatable.Rows[i]["PRI_33"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_34 = dt_Datatable.Rows[i]["PRI_34"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_35 = dt_Datatable.Rows[i]["PRI_35"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_36 = dt_Datatable.Rows[i]["PRI_36"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_37 = dt_Datatable.Rows[i]["PRI_37"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_38 = dt_Datatable.Rows[i]["PRI_38"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_39 = dt_Datatable.Rows[i]["PRI_39"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_40 = dt_Datatable.Rows[i]["PRI_40"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_41 = dt_Datatable.Rows[i]["PRI_41"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_42 = dt_Datatable.Rows[i]["PRI_42"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_43 = dt_Datatable.Rows[i]["PRI_43"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_44 = dt_Datatable.Rows[i]["PRI_44"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_45 = dt_Datatable.Rows[i]["PRI_45"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_46 = dt_Datatable.Rows[i]["PRI_46"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_47 = dt_Datatable.Rows[i]["PRI_47"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_48 = dt_Datatable.Rows[i]["PRI_48"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_49 = dt_Datatable.Rows[i]["PRI_49"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_50 = dt_Datatable.Rows[i]["PRI_50"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_51 = dt_Datatable.Rows[i]["PRI_51"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_52 = dt_Datatable.Rows[i]["PRI_52"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_53 = dt_Datatable.Rows[i]["PRI_53"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_54 = dt_Datatable.Rows[i]["PRI_54"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_55 = dt_Datatable.Rows[i]["PRI_55"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_56 = dt_Datatable.Rows[i]["PRI_56"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_57 = dt_Datatable.Rows[i]["PRI_57"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_58 = dt_Datatable.Rows[i]["PRI_58"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_59 = dt_Datatable.Rows[i]["PRI_59"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_60 = dt_Datatable.Rows[i]["PRI_60"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_61 = dt_Datatable.Rows[i]["PRI_61"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_62 = dt_Datatable.Rows[i]["PRI_62"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_63 = dt_Datatable.Rows[i]["PRI_63"]?.ToString() ?? string.Empty;
        //            objMasterData.PRI_64 = dt_Datatable.Rows[i]["PRI_64"]?.ToString() ?? string.Empty;

        //            lstMasterData.Add(objMasterData);
                   
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return lstMasterData;
        //}
    }
}
