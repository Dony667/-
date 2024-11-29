using System;

public interface IState
{
    void HandleInput(string input);
}

public class OrderContext
{
    private IState _currentState;

    public void SetState(IState state)
    {
        _currentState = state;
        Console.WriteLine($"Состояние: {state.GetType().Name}");
    }

    public void HandleInput(string input) => _currentState?.HandleInput(input);
}

public class IdleState : IState
{
    private OrderContext _context;
    public IdleState(OrderContext context) => _context = context;

    public void HandleInput(string input)
    {
        if (input == "выбрать авто")
            _context.SetState(new CarSelectedState(_context));
    }
}

public class CarSelectedState : IState
{
    private OrderContext _context;
    public CarSelectedState(OrderContext context) => _context = context;

    public void HandleInput(string input)
    {
        if (input == "оформление")
            _context.SetState(new OrderConfirmedState(_context));
        else if (input == "отмена")
            _context.SetState(new TripCancelledState(_context));
    }
}

public class OrderConfirmedState : IState
{
    private OrderContext _context;
    public OrderConfirmedState(OrderContext context) => _context = context;

    public void HandleInput(string input)
    {
        if (input == "авто прибыл")
            _context.SetState(new CarArrivedState(_context));
        else if (input == "отмена")
            _context.SetState(new TripCancelledState(_context));
    }
}

public class CarArrivedState : IState
{
    private OrderContext _context;
    public CarArrivedState(OrderContext context) => _context = context;

    public void HandleInput(string input)
    {
        if (input == "начала поездки")
            _context.SetState(new InTripState(_context));
        else if (input == "отмена")
            _context.SetState(new TripCancelledState(_context));
    }
}

public class InTripState : IState
{
    private OrderContext _context;
    public InTripState(OrderContext context) => _context = context;

    public void HandleInput(string input)
    {
        if (input == "полная поездка")
            _context.SetState(new TripCompletedState(_context));
    }
}

public class TripCompletedState : IState
{
    public void HandleInput(string input) => Console.WriteLine("заказ завершен");
}

public class TripCancelledState : IState
{
    public void HandleInput(string input) => Console.WriteLine("заказ отмена");
}

// Клиентский код
class Program
{
    static void Main()
    {
        var order = new OrderContext();
        order.SetState(new IdleState(order));

        order.HandleInput("SelectCar");
        order.HandleInput("ConfirmOrder");
        order.HandleInput("CarArrived");
        order.HandleInput("StartTrip");
        order.HandleInput("CompleteTrip");
    }
}
