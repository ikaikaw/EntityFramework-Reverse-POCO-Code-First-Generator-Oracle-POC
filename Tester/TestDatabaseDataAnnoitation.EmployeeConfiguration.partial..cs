namespace TestDatabaseDataAnnotation
{
    public partial class EmployeeConfiguration
    {
        partial void InitializePartial()
        {
            HasMany(e => e.Departments)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.ManagerId);

            //HasMany(e => e.Employees)
            //    .WithOptional(e => e.Manager)
            //    .HasForeignKey(e => e.ManagerId);
        }
    }
}