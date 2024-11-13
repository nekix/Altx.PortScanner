using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altx.PortScanner.Clock;

public interface IClock
{
    //
    // Сводка:
    //     Gets Now.
    DateTime Now { get; }

    //
    // Сводка:
    //     Gets kind.
    DateTimeKind Kind { get; }

    //
    // Сводка:
    //     Is that provider supports multiple time zone.
    bool SupportsMultipleTimezone { get; }

    //
    // Сводка:
    //     Normalizes given System.DateTime.
    //
    // Параметры:
    //   dateTime:
    //     DateTime to be normalized.
    //
    // Возврат:
    //     Normalized DateTime
    DateTime Normalize(DateTime dateTime);
}
