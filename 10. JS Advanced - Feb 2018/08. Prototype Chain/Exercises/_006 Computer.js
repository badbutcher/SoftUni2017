function result() {
    class Device {
        constructor(manufacturer) {
            if (new.target === Device) {
                throw new Error('Abstract class cannot be instantiated directly')
            }

            this.manufacturer = manufacturer;
        }
    }

    class Keyboard extends Device {
        constructor(manufacturer, responseTime) {
            super(manufacturer);
            this.responseTime = Number(responseTime);
        }
    }

    class Monitor extends Device {
        constructor(manufacturer, width, height) {
            super(manufacturer);
            this.width = Number(width);
            this.height = Number(height);
        }
    }

    class Battery extends Device {
        constructor(manufacturer, expectedLife) {
            super(manufacturer);
            this.expectedLife = Number(expectedLife);
        }
    }

    class Computer extends Device {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            if (new.target === Computer) {
                throw new Error('Abstract class cannot be instantiated directly');
            }

            super(manufacturer);
            this.processorSpeed = Number(processorSpeed);
            this.ram = Number(ram);
            this.hardDiskSpace = Number(hardDiskSpace);
        }
    }

    class Laptop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = Number(weight);
            this.color = color;
            this.battery = battery;
        }

        get battery() {
            return this._battery;
        }

        set battery(value) {
            if (value instanceof Battery) {
                this._battery = value;
            } else {
                throw new TypeError('Wrong value type.');
            }
        }
    }

    class Desktop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard() {
            return this._keyboard;
        }

        set keyboard(value) {
            if (value instanceof Keyboard) {
                this._keyboard = value;
            } else {
                throw new TypeError('Wrong value type.');
            }

        }

        get monitor() {
            return this._monitor;
        }

        set monitor(value) {
            if (value instanceof Monitor) {
                this._monitor = value;
            } else {
                throw new TypeError('Wrong value type.')
            }
        }
    }

    return {Battery, Keyboard, Monitor, Computer, Laptop, Desktop}
}
