module andytampanSampleTrigger

using ..Ahorn, Maple

@mapdef Trigger "andytampan/SampleTrigger" SampleTrigger(
    x::Integer, y::Integer, width::Integer=Maple.defaultTriggerWidth, height::Integer=Maple.defaultTriggerHeight,
    sampleProperty::Integer=0
)

const placements = Ahorn.PlacementDict(
    "Sample Trigger (andytampan)" => Ahorn.EntityPlacement(
        SampleTrigger,
        "rectangle",
    )
)

end