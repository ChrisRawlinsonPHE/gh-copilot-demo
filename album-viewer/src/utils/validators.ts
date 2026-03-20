// function named `validateDate` which validates a date from text input in a french format and converts it to a date object
export function validateDate(dateString: string): Date | null {
  // Regular expression to match the date format "dd/mm/yyyy"
  const datePattern = /^(\d{2})\/(\d{2})\/(\d{4})$/;
  const match = dateString.match(datePattern);

  if (!match) {
    return null; // Invalid format
  }

  const day = parseInt(match[1], 10);
  const month = parseInt(match[2], 10) - 1; // Months are zero-based in JavaScript
  const year = parseInt(match[3], 10);

  const date = new Date(year, month, day);

  // Check if the date is valid (e.g., not "31/02/2020")
  if (date.getFullYear() === year && date.getMonth() === month && date.getDate() === day) {
    return date;
  }

  return null; // Invalid date
}   

// function that validates the format of a GUID string.
export function validateGUID(guidString: string): string | null {
  const guidPattern = /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/;
  if (guidPattern.test(guidString)) {
    return guidString;
  }
  return null;
}

// function that validates the format of a IPV6 address string and is named `validateIPV6`.
export function validateIPV6(ipv6String: string): string | null {
  const ipv6Pattern = /^(?:[0-9a-fA-F]{1,4}:){7}[0-9a-fA-F]{1,4}$/;
  if (ipv6Pattern.test(ipv6String)) {
    return ipv6String;
  }
  return null;
}   

