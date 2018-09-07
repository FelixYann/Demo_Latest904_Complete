using UnityEngine;

public class ClassCorridor
{
    public int startXPos;         // The x coordinate for the start of the corridor.
    public int startYPos;         // The y coordinate for the start of the corridor.
    public int corridorLength;    // How many units long the corridor is.
    public Direction direction;   // Which direction the corridor is heading from it's room.
    public ClassRoom from, to;    // 测试用 可删除

    public void SetupCorridor(ClassRoom fromRoom, ClassRoom toRoom, int num_direction)
    {
        direction = (Direction)num_direction;

        switch (direction)
        {
            // If the choosen direction is North (up)...
            case Direction.North:
                if(fromRoom.type == RoomType.CorrNode)
                {
                    startXPos = fromRoom.xPos;
                }
                else if(toRoom.type == RoomType.CorrNode)
                {
                    startXPos = toRoom.xPos;
                }
                else
                {
                    startXPos = Random.Range(Mathf.Max(fromRoom.xPos + 1, toRoom.xPos + 1), Mathf.Min(fromRoom.xPos + fromRoom.roomWidth - 2, toRoom.xPos + toRoom.roomWidth - 2));
                }
                // The starting position in the y axis must be the top of the room.
                startYPos = fromRoom.yPos + fromRoom.roomHeight - 1;
                // The maximum length the corridor can be is the height of the board (rows) but from the top of the room (y pos + height).
                corridorLength = toRoom.yPos -startYPos + 1;
                break;
            case Direction.East:
                if (fromRoom.type == RoomType.CorrNode)
                {
                    startYPos = fromRoom.yPos;
                }
                else if (toRoom.type == RoomType.CorrNode)
                {
                    startYPos = toRoom.yPos;
                }
                else
                {
                    startYPos = Random.Range(Mathf.Max(fromRoom.yPos + 1, toRoom.yPos + 1), Mathf.Min(fromRoom.yPos + fromRoom.roomHeight - 2, toRoom.yPos + toRoom.roomHeight - 2));
                }
                startXPos = fromRoom.xPos + fromRoom.roomWidth - 1;
                corridorLength = toRoom.xPos - startXPos + 1;
                break;
            case Direction.South:
                if (fromRoom.type == RoomType.CorrNode)
                {
                    startXPos = fromRoom.xPos;
                }
                else if (toRoom.type == RoomType.CorrNode)
                {
                    startXPos = toRoom.xPos;
                }
                else
                {
                    startXPos = Random.Range(Mathf.Max(fromRoom.xPos + 1, toRoom.xPos + 1), Mathf.Min(fromRoom.xPos + fromRoom.roomWidth - 2, toRoom.xPos + toRoom.roomWidth - 2));
                }
                startYPos = fromRoom.yPos;
                corridorLength = startYPos - toRoom.yPos - toRoom.roomHeight + 1;
                break;
            case Direction.West:
                if (fromRoom.type == RoomType.CorrNode)
                {
                    startYPos = fromRoom.yPos;
                }
                else if (toRoom.type == RoomType.CorrNode)
                {
                    startYPos = toRoom.yPos;
                }
                else
                {
                    startYPos = Random.Range(Mathf.Max(fromRoom.yPos + 1, toRoom.yPos + 1), Mathf.Min(fromRoom.yPos + fromRoom.roomHeight - 2, toRoom.yPos + toRoom.roomHeight - 2));
                }
                startXPos = fromRoom.xPos;
                corridorLength = startXPos - toRoom.xPos - toRoom.roomWidth + 1;
                break;
        }
    }
}