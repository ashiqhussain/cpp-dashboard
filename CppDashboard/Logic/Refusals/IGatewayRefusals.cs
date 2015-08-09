namespace CppDashboard.Logic.Refusals
{
    public interface IGatewayRefusals
    {
        /// <summary>
        /// Returns the number of refusals at the Gateway level. No payment record is created at this level
        /// as it is a validation error.
        /// </summary>
        RefuseSummary GetTotal();
    }
}