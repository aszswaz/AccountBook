type HTMLInputElementORNull = HTMLInputElement | null

export function getInputElement(inputId: string): HTMLInputElement {
    const element = <HTMLInputElementORNull>document.getElementById(inputId)
    if (!element) throw new Error(`元素 ${inputId} 不存在`)
    return element
}

export function getInputValue(inputId: string): string {
    const element = getInputElement(inputId)
    return element.value
}