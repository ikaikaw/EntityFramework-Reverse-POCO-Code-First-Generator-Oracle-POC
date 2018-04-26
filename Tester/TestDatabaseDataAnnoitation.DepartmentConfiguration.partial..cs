namespace TestDatabaseDataAnnotation
{
    public partial class DepartmentConfiguration
    {
        partial void InitializePartial()
        {
            //HasMany(e => e.Employees)
            //    .WithOptional(e => e.Department)
            //    .HasForeignKey(e => e.DepartmentId);
        }
    }
}