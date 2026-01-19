local drawableSprite = require("structs.drawable_sprite")

local DirectionBooster = {
    name = "andytampan/DirectionBooster",
    depth = -8500,
    placements = {
                {
            name = "Direction Booster (Green, Up)",
            data = {
                red = false,
                arrow = true,
                direction = "up"
            },

        },
                {
            name = "Direction Booster (Green, Right)",
            data = {
                red = false,
                arrow = true,
                direction = "right"
            },

        },
                {
            name = "Direction Booster (Green, Down)",
            data = {
                red = false,
                arrow = true,
                direction = "down"
            },

        },
                {
            name = "Direction Booster (Green, Left)",
            data = {
                red = false,
                arrow = true,
                direction = "left"
            },

        },
                {
            name = "Direction Booster (Red, Up)",
            data = {
                red = true,
                arrow = true,
                direction = "up"
            },

        },
                {
            name = "Direction Booster (Red, Right)",
            data = {
                red = true,
                arrow = true,
                direction = "right"
            },

        },
                {
            name = "Direction Booster (Red, Down)",
            data = {
                red = true,
                arrow = true,
                direction = "down"
            },

        },
                {
            name = "Direction Booster (Red, Left)",
            data = {
                red = true,
                arrow = true,
                direction = "left"
            },

        },
    },
  
    fieldInformation = {
        direction = {
            options = {"up","upright","right","downright","down","downleft","left","upleft"},
            editable = true,
            }
         },
      }
    

function DirectionBooster.sprite(room, entity)
    local spriteTexture = entity.red and "objects/booster/boosterRed00" or "objects/booster/booster00"
    local boosterSprite = drawableSprite.fromTexture(spriteTexture, entity)
    arrowTexture = "objects/andytampan/directionBooster/lonnwhy"
    angle = 0
    if entity.arrow == true then
        if entity.direction == "upright" then
        arrowTexture = "objects/andytampan/directionBooster/arrowDiagonal00"
        angle = 0
        elseif entity.direction == "right" then
        arrowTexture = "objects/andytampan/directionBooster/arrowHorizontal00"
        angle = 0
        elseif entity.direction == "downright" then
        arrowTexture = "objects/andytampan/directionBooster/arrowDiagonal00"
        angle = 1
        elseif entity.direction == "down" then
        arrowTexture = "objects/andytampan/directionBooster/arrowHorizontal00"
        angle = 1
        elseif entity.direction == "downleft" then
        arrowTexture = "objects/andytampan/directionBooster/arrowDiagonal00"
        angle = 2
        elseif entity.direction == "left" then
        arrowTexture = "objects/andytampan/directionBooster/arrowHorizontal00"
        angle = 2
        elseif entity.direction == "upleft" then
        arrowTexture = "objects/andytampan/directionBooster/arrowDiagonal00"
        angle = 3
        elseif entity.direction == "up" then
        arrowTexture = "objects/andytampan/directionBooster/arrowHorizontal00"
        angle = 3
        end
        
    end
    local arrowSprite = drawableSprite.fromTexture(arrowTexture, entity)
        arrowSprite.rotation = math.rad(90*angle)
    return {boosterSprite, arrowSprite}
end

return DirectionBooster