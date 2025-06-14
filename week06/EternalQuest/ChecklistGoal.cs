using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _target;
        private int _bonus;
        private int _amountCompleted;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) 
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _amountCompleted++;
                if (_amountCompleted >= _target)
                {
                    _isComplete = true;
                    return _points + _bonus;
                }
                return _points;
            }
            return 0;
        }

        public override string GetDisplayString()
        {
            string checkbox = _isComplete ? "[X]" : "[ ]";
            return $"{checkbox} {_name} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
        }
    }
} 