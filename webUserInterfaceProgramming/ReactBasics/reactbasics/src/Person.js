export default function Person({ person }) {
    return (
        <div>
            <p>{person.name}</p>
            <img src={person.image}></img>
        </div>
    )
}