namespace Core.Model
{
    public class Solution : BaseEntity
    {
        public Solution(int id)
        {
            this.Id = id;
        }
        public string Name { get; set; }
        /// <summary>
        /// data which contains details about a submission.
        /// </summary>
        public string Json { get; set; }


    }
}