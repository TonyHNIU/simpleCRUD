import React from "react"
import ReactDOM from "react-dom"

export default class Example extends React.Component {

    render() {
        return (
            <div>
                <h1>Welcome</h1>
                <p>Before 4.8 building application(watching video, search information online and reference other code)</p>
                <p>4.9 Fixing buttons</p>
                <p>4.10 Pubilsh on Github</p>
            </div>
        )
    }
}


const root = document.getElementById("root")
ReactDOM.render(<Example />, root)