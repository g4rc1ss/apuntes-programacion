using MapperlyLibrary.ClassToMap;
using MapperlyLibrary.Profiles;

MapperlyProfile? mapperly = new();

ChatDto? chatDto = mapperly.ToChatDto(ClassFake.chatClass);

IEnumerable<ChatDto>? chatsDto = ClassFake.chatEntityList.Select(mapperly.ToChatDto);

foreach (ChatDto? chat in chatsDto)
{
    Console.WriteLine(chat.Id);
}
