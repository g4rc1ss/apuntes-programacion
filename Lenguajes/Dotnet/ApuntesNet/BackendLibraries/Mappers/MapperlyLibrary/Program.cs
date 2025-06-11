using MapperlyLibrary.ClassToMap;
using MapperlyLibrary.Profiles;

MapperlyProfile? mapperly = new();

ChatDTO? chatDTO = mapperly.ToChatDTO(ClassFake.chatClass);

IEnumerable<ChatDTO>? chatsDTO = ClassFake.chatEntityList.Select(mapperly.ToChatDTO);

foreach (ChatDTO? chat in chatsDTO)
{
    Console.WriteLine(chat.Id);
}
