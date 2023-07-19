using FluentAssertions;
using Host.Components;
using Host.Interfaces;

namespace UnitTests.Components
{
    public class ChunkedEncodingProcessorTests
    {
        private readonly Mock<IEncoder> _encoderMock;
        private readonly Mock<IProcessingSimulator> _processingSimulatorMock;
        private readonly IEncodingProcessor _processor;

        public ChunkedEncodingProcessorTests()
        {
            _encoderMock = new Mock<IEncoder>();
            _processingSimulatorMock = new Mock<IProcessingSimulator>();

            _processor = new ChunkedEncodingProcessor(_encoderMock.Object, _processingSimulatorMock.Object);
        }

        [Fact]
        public async Task ProcessAsync_MultipleChunks_ProcessesAllChunks()
        {
            // Arrange
            string data = "test";
            string encoded = "12";
            CancellationToken ct = new();

            var callback = new Mock<Func<string, Task>>();

            _encoderMock
                .Setup(x => x.Encode(data))
                .Returns(encoded)
                .Verifiable();

            _processingSimulatorMock
                .Setup(x => x.SimulateAsync(ct))
                .Verifiable();

            // Act
            await _processor.ProcessAsync(data, callback.Object, ct);

            // Assert
            _encoderMock.Verify();
            _processingSimulatorMock.Verify();
            callback.Verify(x => x.Invoke(It.IsAny<string>()), Times.Exactly(2));
            callback.Verify(x => x.Invoke("1"));
            callback.Verify(x => x.Invoke("2"));
        }

        [Fact]
        public async Task ProcessAsync_CancellationCalled_OperationCanceledExceptionThrown()
        {
            // Arrange
            string data = "test";
            string encoded = "12";
            CancellationToken ct = new(true);

            var callback = new Mock<Func<string, Task>>();

            _encoderMock
                .Setup(x => x.Encode(data))
                .Returns(encoded)
                .Verifiable();

            // Act
            Func<Task> act = async () => await _processor.ProcessAsync(data, callback.Object, ct);

            // Assert
            await act.Should().ThrowAsync<OperationCanceledException>();
            _processingSimulatorMock.Verify(x => x.SimulateAsync(ct), Times.Never);
            callback.Verify(x => x.Invoke(It.IsAny<string>()), Times.Never);
        }
    }
}
