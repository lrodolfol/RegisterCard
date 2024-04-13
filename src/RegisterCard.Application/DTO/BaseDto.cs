namespace RegisterCard.Application.DTO;
public abstract record BaseDto
{
    protected List<string> _listNotifications = new();
    public IReadOnlyCollection<string> Notifications => _listNotifications;
    public bool IsValid => !_listNotifications.Any();
}
