namespace Ameware.Test
{
	public record Item//(int Id, string Text, int Parent)
	{
		public int Id { get; init; }
		public string Text { get; init; }
		public int Parent { get; init; }
	}
}