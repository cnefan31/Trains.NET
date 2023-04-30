﻿using Trains.NET.Engine;
using static Trains.NET.Tests.TrainMovementTestsHelper;

namespace Trains.NET.Tests;

public class ClockwiseCounterClockwise
{
    [Theory]
    [InlineData(0.0f, HalfCornerTrackDistance, Angle90InRads, Angle45InRads, 0)] // 0-90, within arc
    [InlineData(0.0f, HalfCornerTrackDistance * 2, Angle90InRads, Angle90InRads, 0)] // 0-90, on edge of arc
    [InlineData(0.0f, HalfCornerTrackDistance * 3, Angle90InRads, Angle90InRads + 0.1f, HalfCornerTrackDistance)] // 0-90, beyond arc
    [InlineData(Angle90InRads, HalfCornerTrackDistance, Angle180InRads, Angle135InRads, 0)] // 90-180, within arc
    [InlineData(Angle90InRads, HalfCornerTrackDistance * 2, Angle180InRads, Angle180InRads, 0)] // 90-180, on edge of arc
    [InlineData(Angle90InRads, HalfCornerTrackDistance * 3, Angle180InRads, Angle180InRads + 0.1f, HalfCornerTrackDistance)] // 90-180, beyond arc
    [InlineData(Angle180InRads, HalfCornerTrackDistance, Angle270InRads, Angle225InRads, 0)] // 180-270, within arc
    [InlineData(Angle180InRads, HalfCornerTrackDistance * 2, Angle270InRads, Angle270InRads, 0)] // 180-270, on edge of arc
    [InlineData(Angle180InRads, HalfCornerTrackDistance * 3, Angle270InRads, Angle270InRads + 0.1f, HalfCornerTrackDistance)] // 180-270, beyond arc
    [InlineData(Angle270InRads, HalfCornerTrackDistance, Angle360InRads, Angle315InRads, 0)] // 270-360, within arc
    [InlineData(Angle270InRads, HalfCornerTrackDistance * 2, Angle360InRads, Angle360InRads, 0)] // 270-360, on edge of arc
    [InlineData(Angle270InRads, HalfCornerTrackDistance * 3, Angle360InRads, 0.1f, HalfCornerTrackDistance)] // 270-360, beyond arc
    public void MoveClockwise(double currentAngle, float distance, float maximumNewAngle, float expectedAngle, float expectedDistance)
    {
        (double newAngle, float newDistance) = TrainMovement.MoveClockwise(currentAngle, distance, maximumNewAngle);

        Assert.Equal(expectedAngle, newAngle, 3f);
        Assert.Equal(expectedDistance, newDistance, 3f);
    }

    [Theory]
    [InlineData(Angle90InRads, HalfCornerTrackDistance, 0.0f, Angle45InRads, 0)] // 0-90, within arc
    [InlineData(Angle90InRads, HalfCornerTrackDistance * 2, 0.0f, 0.0f, 0)] // 0-90, on edge of arc
    [InlineData(Angle90InRads, HalfCornerTrackDistance * 3, 0.0f, -0.1f, HalfCornerTrackDistance)] // 0-90, beyond arc
    [InlineData(Angle180InRads, HalfCornerTrackDistance, Angle90InRads, Angle135InRads, 0)] // 90-180, within arc
    [InlineData(Angle180InRads, HalfCornerTrackDistance * 2, Angle90InRads, Angle90InRads, 0)] // 90-180, on edge of arc
    [InlineData(Angle180InRads, HalfCornerTrackDistance * 3, Angle90InRads, Angle90InRads - 0.1f, HalfCornerTrackDistance)] // 90-180, beyond arc
    [InlineData(Angle270InRads, HalfCornerTrackDistance, Angle180InRads, Angle225InRads, 0)] // 180-270, within arc
    [InlineData(Angle270InRads, HalfCornerTrackDistance * 2, Angle180InRads, Angle180InRads, 0)] // 180-270, on edge of arc
    [InlineData(Angle270InRads, HalfCornerTrackDistance * 3, Angle180InRads, Angle180InRads - 0.1f, HalfCornerTrackDistance)] // 180-270, beyond arc
    [InlineData(Angle360InRads, HalfCornerTrackDistance, Angle270InRads, Angle315InRads, 0)] // 270-360, within arc
    [InlineData(Angle360InRads, HalfCornerTrackDistance * 2, Angle270InRads, Angle270InRads, 0)] // 270-360, on edge of arc
    [InlineData(Angle360InRads, HalfCornerTrackDistance * 3, Angle270InRads, Angle270InRads - 0.1f, HalfCornerTrackDistance)] // 270-360, beyond arc
    public void MoveCounterClockwise(double currentAngle, float distance, float maximumNewAngle, float expectedAngle, float expectedDistance)
    {
        (double newAngle, float newDistance) = TrainMovement.MoveCounterClockwise(currentAngle, distance, maximumNewAngle);

        Assert.Equal(expectedAngle, newAngle, 3f);
        Assert.Equal(expectedDistance, newDistance, 3f);
    }
}
