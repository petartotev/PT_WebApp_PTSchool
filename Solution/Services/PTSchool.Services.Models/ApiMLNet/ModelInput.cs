using Microsoft.ML.Data;

namespace PTSchool.Services.Models.ApiMLNet
{
    public class ModelInput
    {
        [ColumnName("StudentId"), LoadColumn(0)]
        public string StudentId { get; set; }


        [ColumnName("ClubId"), LoadColumn(1)]
        public string ClubId { get; set; }


        [ColumnName("Score"), LoadColumn(2)]
        public float Score { get; set; }
    }
}
