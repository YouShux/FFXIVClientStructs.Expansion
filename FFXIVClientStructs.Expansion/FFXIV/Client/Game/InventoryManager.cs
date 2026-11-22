using FFXIVClientStructs.FFXIV.Client.Game;
using NativeInventoryManager = FFXIVClientStructs.FFXIV.Client.Game.InventoryManager;

namespace FFXIVClientStructs.Expansion.FFXIV.Client.Game;

/// <summary>提供临时交付栏及住宅家具的背包操作接口。</summary>
[GenerateInterop]
[Inherits<NativeInventoryManager>]
[StructLayout(LayoutKind.Explicit, Size = 14128)]
public unsafe partial struct InventoryManager
{
    /// <summary>将指定背包家具存入当前室内仓库，由客户端检查仓库剩余栏位并发送存入请求。</summary>
    /// <param name="item">需要存入仓库的背包家具。</param>
    [MemberFunction("48 85 D2 0F 84 ?? ?? ?? ?? 56 57 48 81 EC")]
    public partial void StoreInteriorFurniture(InventoryItem* item);

    /// <summary>将指定背包庭具存入指定住宅的室外仓库，由客户端检查仓库剩余栏位并发送存入请求。</summary>
    /// <param name="houseID">目标住宅的完整标识。</param>
    /// <param name="item">需要存入仓库的背包庭具。</param>
    [MemberFunction("4D 85 C0 0F 84 ?? ?? ?? ?? 55 56 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 49 8B 00 48 8B F1")]
    public partial void StoreExteriorFurniture(ulong houseID, InventoryItem* item);

    /// <summary>将背包物品关联到临时栏位，并按需发送物品占用请求。</summary>
    /// <param name="item">需要占用的背包物品。</param>
    /// <param name="destinationType">目标临时容器类型。</param>
    /// <param name="destinationSlot">目标临时栏位序号。</param>
    /// <param name="sendPacket">是否向服务器发送占用请求。</param>
    /// <returns>成功时返回零，否则返回客户端的背包操作错误码。</returns>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 54 41 57 48 83 EC ?? 4C 8B F9")]
    public partial int ReserveItem(InventoryItem* item, InventoryType destinationType, short destinationSlot, bool sendPacket);

    /// <summary>清除临时栏位的物品关联，并按需发送物品释放请求。</summary>
    /// <param name="inventoryType">需要释放的临时容器类型。</param>
    /// <param name="slot">需要释放的临时栏位序号。</param>
    /// <param name="sendPacket">是否向服务器发送释放请求。</param>
    /// <returns>成功时返回零，否则返回客户端的背包操作错误码。</returns>
    [MemberFunction("48 89 6C 24 ?? 57 41 54 41 56 48 83 EC ?? 4D 0F BF E0")]
    public partial int ReleaseItem(InventoryType inventoryType, short slot, bool sendPacket);
}
