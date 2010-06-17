namespace SpikeRhinoSecurity.Domain
{
	public static class EmployeeTerritoriesAssociationSynchronizer
	{
		public static void Associate(SpikeRhinoSecurity.Domain.Territory item1, SpikeRhinoSecurity.Domain.Employee item2)
		{
			item1.Employees.Add(item2);
			item2.Territories.Add(item1);
		}

		public static void Disassociate(SpikeRhinoSecurity.Domain.Territory item1, SpikeRhinoSecurity.Domain.Employee item2)
		{
			item1.Employees.Remove(item2);
			item2.Territories.Remove(item1);
		}

	}
}