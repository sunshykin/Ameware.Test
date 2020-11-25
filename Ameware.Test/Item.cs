namespace Ameware.Test
{
	/*
	 * Records require at least init to be filled from JSON.
	 * Also there could be something like 'public record Item(int Id, string Text, int Parent) {}'
	 */
	public record Item
	{
		public int Id { get; init; }
		public string Text { get; init; }
		public int Parent { get; init; }
	}
}