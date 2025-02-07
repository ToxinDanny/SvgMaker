import './App.css';
import { useState, useEffect } from 'react';

function App() {
    const [svgSettings, setSvgSettings] = useState();
    const [perimeter, setPerimeter] = useState();
    const [coordinates, setCoordinates] = useState();
    
    useEffect(() => { getSvgSettings() });

    return (
        <div>
            <svg
                width={svgSettings?.svgWidth}
                height={svgSettings?.svgHeight}
                style={{ fill: 'black' }}
                onMouseDown={startResize}
                onMouseUp={stopResize}
                xmlns="http://www.w3.org/2000/svg">
                
                <rect
                    width={svgSettings?.rectWidth}
                    height={svgSettings?.rectHeight}
                    x="5"
                    y="5"
                    style={{ fill: 'white' }}
                />
            </svg >
            <div>Perimeter:{perimeter} </div> 
        </div>
    );

    async function getSvgSettings() {

        const response = await fetch("svg");

        if (response.ok) {
            const data = await response.json();
            const settings = {
                svgWidth: parseInt(data.width) + 10,
                svgHeight: parseInt(data.height) + 10,
                rectWidth: data.width,
                rectHeight: data.height
            }

            setSvgSettings(settings);

            const p = parseInt(data.width) * 2 + parseInt(data.height) * 2;
            setPerimeter(p);
        }
    }

    function startResize(e) {
        let c = { width: e?.clientX - 10, height: e?.clientY - 10 };
        setCoordinates(c);
    }

    function stopResize(e) {
        let c = {
            width: e?.clientX - coordinates?.clientX,
            height: e?.clientY - coordinates?.clientY
        };
        setCoordinates(c);
        const p = parseInt(svgSettings?.width) * 2 + parseInt(svgSettings?.height) * 2;
        setPerimeter(p);
    }
}

export default App;